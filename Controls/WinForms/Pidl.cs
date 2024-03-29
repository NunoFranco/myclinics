﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ClearCanvas.Controls.WinForms
{
	/// <summary>
	/// A managed wrapper type for shell PIDLs (pointers to ITEMIDLISTs).
	/// </summary>
	public sealed class Pidl : IDisposable, ICloneable, IEquatable<Pidl>
	{
		private IntPtr _pidl;
		private bool _disposed = false;

		public Pidl(IntPtr pidl) : this(pidl, false) {}

		public Pidl(Environment.SpecialFolder specialFolder) : this(CreateSpecialFolderPidl(specialFolder), true) {}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Use this override with great care when specifying <paramref name="isPreallocatedPidl"/> = True.
		/// </remarks>
		/// <param name="pidl"></param>
		/// <param name="isPreallocatedPidl"></param>
		private Pidl(IntPtr pidl, bool isPreallocatedPidl)
		{
			if (IntPtr.Zero.Equals(pidl))
				throw new ArgumentOutOfRangeException("pidl", "PIDL cannot be NULL.");

			if (isPreallocatedPidl)
				_pidl = pidl;
			else
				_pidl = ILClone(pidl);

#if DEBUG
			_instanceCount++;
#endif
		}

		public Pidl(Pidl parentPidl, Pidl childPidl) : this(parentPidl.GetPidl(), childPidl.GetPidl()) {}

		public Pidl(IntPtr parentPidl, IntPtr childPidl)
		{
			if (IntPtr.Zero.Equals(parentPidl) || IntPtr.Zero.Equals(childPidl))
				throw new ArgumentOutOfRangeException("childPidl", "PIDL cannot be NULL.");
			_pidl = ILCombine(parentPidl, childPidl);

#if DEBUG
			_instanceCount++;
#endif
		}

		~Pidl()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
#if DEBUG
			--_instanceCount;
#endif
			if (!_disposed)
			{
				if (!IntPtr.Zero.Equals(_pidl))
				{
					Marshal.FreeCoTaskMem(_pidl);
					_pidl = IntPtr.Zero;
				}

				_disposed = true;
			}
		}

		public string Path
		{
			get
			{
				StringBuilder strBuffer = new StringBuilder(Native.MAX_PATH);
				Native.Shell32.SHGetPathFromIDList(this.GetPidl(), strBuffer);
				return strBuffer.ToString();
			}
		}

		public string DisplayName
		{
			get
			{
				IntPtr pidl = this.GetPidl();
				Native.SHFILEINFO shInfo = new Native.SHFILEINFO();
				Native.Shell32.SHGetFileInfo(pidl, 0, out shInfo, (uint) Marshal.SizeOf(shInfo), Native.SHGFI.SHGFI_PIDL | Native.SHGFI.SHGFI_DISPLAYNAME);
				return shInfo.szDisplayName;
			}
		}

		public string VirtualPath
		{
			get
			{
				using (Pidl pidl = this.Clone())
				{
					Stack<string> stack = new Stack<string>();
					string displayName = this.DisplayName;
					int countChars = displayName.Length;

					stack.Push(displayName);
					while (ILRemoveLastID((IntPtr) pidl))
					{
						displayName = pidl.DisplayName;
						countChars += displayName.Length;
						stack.Push(displayName);
					}

					StringBuilder sb = new StringBuilder(countChars + stack.Count - 1);
					while (stack.Count > 0)
					{
						sb.Append(stack.Pop());
						if (stack.Count > 0)
							sb.Append(System.IO.Path.DirectorySeparatorChar);
					}
					return sb.ToString();
				}
			}
		}

		public bool IsRoot
		{
			get
			{
				IntPtr pidl = this.GetPidl();
				pidl = ILClone(pidl);
				try
				{
					return !ILRemoveLastID(pidl);
				}
				finally
				{
					Marshal.FreeCoTaskMem(pidl);
				}
			}
		}

		public bool IsFolder
		{
			get
			{
				const Native.SFGAO REQUEST_ATTRIBUTES = Native.SFGAO.SFGAO_FOLDER | Native.SFGAO.SFGAO_HASSUBFOLDER;
				IntPtr pidl = this.GetPidl();
				Native.SHFILEINFO shInfo = new Native.SHFILEINFO();
				Native.Shell32.SHGetFileInfo(pidl, (uint) REQUEST_ATTRIBUTES, out shInfo, (uint) Marshal.SizeOf(shInfo),
				                             Native.SHGFI.SHGFI_PIDL | Native.SHGFI.SHGFI_ATTRIBUTES);
				return (((Native.SFGAO) shInfo.dwAttributes) & Native.SFGAO.SFGAO_FOLDER) != 0;
			}
		}

		public Pidl Clone()
		{
			return new Pidl(this.GetPidl());
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public bool Equals(Pidl otherPidl)
		{
			if (otherPidl == null)
				return false;
			return ILIsEqual(this.GetPidl(), otherPidl.GetPidl());
		}

		public override bool Equals(object obj)
		{
			if (obj is Pidl)
				return this.Equals((Pidl) obj);
			if (obj is IntPtr) // if we're comparing against an IntPtr, don't throw any disposed object exceptions
				return ILIsEqual(_pidl, (IntPtr) obj);
			return false;
		}

		public override int GetHashCode()
		{
			// don't throw any disposed object exceptions
			return _pidl.GetHashCode();
		}

		public override string ToString()
		{
			// don't throw any disposed object exceptions
			return _pidl.ToString();
		}

		public string ToString(string format)
		{
			// don't throw any disposed object exceptions
			return _pidl.ToString(format);
		}

		public bool IsParentOf(Pidl testPidl)
		{
			return ILIsParent(this.GetPidl(), testPidl.GetPidl(), true);
		}

		public bool IsAncestorOf(Pidl testPidl)
		{
			return ILIsParent(this.GetPidl(), testPidl.GetPidl(), false);
		}

		public Pidl GetParent()
		{
			IntPtr pidl = this.GetPidl();
			pidl = ILClone(pidl);
			if (ILRemoveLastID(pidl))
				return new Pidl(pidl, true);
			Marshal.FreeCoTaskMem(pidl);
			return null;
		}

		private IntPtr GetPidl()
		{
			if (IntPtr.Zero.Equals(_pidl))
				throw new ObjectDisposedException("PIDL");
			return _pidl;
		}

		public static Pidl Parse(string path)
		{
			Exception exception;
			Pidl result;
			if (!TryParse(path, out result, out exception))
				throw new PathNotFoundException(path, exception);
			return result;
		}

		public static bool TryParse(string path, out Pidl result)
		{
			Exception exception;
			return TryParse(path, out result, out exception);
		}

		private static bool TryParse(string path, out Pidl result, out Exception exception)
		{
			exception = null;
			result = null;
			if (Native.Shell32.IsSHParseDisplayNameSupported)
			{
				IntPtr pidl = IntPtr.Zero;
				Native.SFGAO flags = 0;
				int hResult = Native.Shell32.SHParseDisplayName(path, IntPtr.Zero, out pidl, 0, out flags);
				if (hResult == 0)
				{
					result = new Pidl(pidl, true);
					return true;
				}
				else
				{
					exception = Marshal.GetExceptionForHR(hResult);
				}
			}
			else
			{
				if (System.IO.Path.IsPathRooted(path))
				{
					if (Directory.Exists(path) || File.Exists(path))
					{
						if (Directory.Exists(path) && !path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
							path += System.IO.Path.DirectorySeparatorChar;
						IntPtr pidl = ILCreateFromPath(path);
						if (!IntPtr.Zero.Equals(pidl))
						{
							result = new Pidl(pidl, true);
							return true;
						}
						else
						{
							exception = new IOException("ILCreateFromPath failed to return a proper PIDL.");
						}
					}
					else
					{
						exception = new FileNotFoundException("The specified path does not exist.", path);
					}
				}
				else
				{
					exception = new ArgumentException("The specified path must be absolute.", "path");
				}
			}
			return false;
		}

		public static Pidl operator +(Pidl parentPidl, Pidl childPidl)
		{
			return new Pidl(parentPidl, childPidl);
		}

		public static bool operator ==(Pidl pidl1, Pidl pidl2)
		{
			if (ReferenceEquals(pidl1, pidl2))
				return true;
			if (!ReferenceEquals(pidl1, null))
				return pidl1.Equals(pidl2);
			return pidl2.Equals(pidl1);
		}

		public static bool operator !=(Pidl pidl1, Pidl pidl2)
		{
			if (ReferenceEquals(pidl1, pidl2))
				return false;
			if (!ReferenceEquals(pidl1, null))
				return !pidl1.Equals(pidl2);
			return !pidl2.Equals(pidl1);
		}

		public static explicit operator IntPtr(Pidl pidl)
		{
			return pidl.GetPidl();
		}

		internal static IEnumerable<Pidl> ConvertPidlEnumeration(Native.IEnumIDList pEnum)
		{
			List<Pidl> children = new List<Pidl>();

			IntPtr pidl = IntPtr.Zero;
			int count = 0;

			// get the first value in the enumeration (the args in the native method signature are more "ref" rather than "out")
			pEnum.Next(1, out pidl, out count);

			// check and loop if value is valid
			while (!IntPtr.Zero.Equals(pidl) && count == 1)
			{
				children.Add(new Pidl(pidl, true));

				// reset counters (required, see note above)
				pidl = IntPtr.Zero;
				count = 0;

				// get the next value in the enumeration
				pEnum.Next(1, out pidl, out count);
			}

			return children;
		}

		private static IntPtr CreateSpecialFolderPidl(Environment.SpecialFolder folder)
		{
			Native.CSIDL csidl;
			switch (folder)
			{
				case Environment.SpecialFolder.MyComputer:
					csidl = Native.CSIDL.CSIDL_DRIVES;
					break;
				case Environment.SpecialFolder.MyDocuments:
					csidl = Native.CSIDL.CSIDL_PERSONAL;
					break;
				case Environment.SpecialFolder.MyMusic:
					csidl = Native.CSIDL.CSIDL_MYMUSIC;
					break;
				case Environment.SpecialFolder.MyPictures:
					csidl = Native.CSIDL.CSIDL_MYPICTURES;
					break;
				case Environment.SpecialFolder.Desktop:
					csidl = Native.CSIDL.CSIDL_DESKTOP;
					break;
				default:
					throw new NotSupportedException("The specified SpecialFolder is not supported.");
			}

			IntPtr pidl;
			int hResult = Native.Shell32.SHGetFolderLocation(IntPtr.Zero, csidl, IntPtr.Zero, 0, out pidl);
			if (hResult != 0)
				throw new Exception("SHGetFolderLocation failed to return the PIDL of the specified SpecialFolder.", Marshal.GetExceptionForHR(hResult));
			return pidl;
		}

		#region ITEMIDLIST Shell32 Functions

		// ReSharper disable InconsistentNaming

		/// <summary>
		/// Clones an ITEMIDLIST structure.
		/// </summary>
		/// <remarks>
		/// <para>When you are finished with the cloned ITEMIDLIST structure, release it with <see cref="ILFree"/> to avoid memory leaks.</para>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport("shell32.dll")]
		private static extern IntPtr ILClone(IntPtr pidl);

		/// <summary>
		/// Combines two ITEMIDLIST structures.
		/// </summary>
		/// <remarks>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="pIDLParent">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pIDLChild">A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.</param>
		/// <returns>Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to <see cref="IntPtr.Zero"/>, the returned ITEMIDLIST structure is a clone of the non-<see cref="IntPtr.Zero"/> parameter. Returns <see cref="IntPtr.Zero"/> if pidl1 and pidl2 are both set to <see cref="IntPtr.Zero"/>.</returns>
		[DllImport("shell32.dll")]
		private static extern IntPtr ILCombine(IntPtr pIDLParent, IntPtr pIDLChild);

		/// <summary>
		/// Returns the ITEMIDLIST structure associated with a specified file path.
		/// </summary>
		/// <remarks>
		/// <para>Call ILFree to release the ITEMIDLIST when you are finished with it.</para>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="pszPath">A NULL-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in length, including the terminating NULL character.</param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = false)]
		private static extern IntPtr ILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

		/// <summary>
		/// Tests whether two ITEMIDLIST structures are equal in a binary comparison.
		/// </summary>
		/// <remarks>
		/// <para>ILIsEqual performs a binary comparison of the item data. It is possible for two ITEMIDLIST structures to differ at the binary level while referring to the same item. IShellFolder::CompareIDs should be used to perform a non-binary comparison.</para>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="pidl1">The first ITEMIDLIST structure.</param>
		/// <param name="pidl2">The second ITEMIDLIST structure.</param>
		/// <returns>Returns TRUE if the two structures are equal, FALSE otherwise.</returns>
		[DllImport("shell32.dll")]
		[return : MarshalAs(UnmanagedType.Bool)]
		private static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

		/// <summary>
		/// Frees an ITEMIDLIST structure allocated by the Shell.
		/// </summary>
		/// <remarks>
		/// <para>ILFree is often used with ITEMIDLIST structures allocated by one of the other IL functions, but it can be used to free any such structure returned by the Shell—for example, the ITEMIDLIST structure returned by SHBrowseForFolder or used in a call to SHGetFolderLocation.</para>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be freed. This parameter can be NULL.</param>
		[DllImport("shell32.dll")]
		[Obsolete("When using Microsoft Windows 2000 or later, use CoTaskMemFree rather than ILFree. ITEMIDLIST structures are always allocated with the Component Object Model (COM) task allocator on those platforms.")]
		private static extern void ILFree(IntPtr pidl);

		/// <summary>
		/// Removes the last SHITEMID structure from an ITEMIDLIST structure.
		/// </summary>
		/// <remarks>
		/// <para>Requires at least Windows 2000.</para>
		/// </remarks>
		/// <param name="fullPidl">A pointer to the ITEMIDLIST structure to be shortened. When the function returns, this variable points to the shortened structure.</param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		[DllImport("shell32.dll")]
		[return : MarshalAs(UnmanagedType.Bool)]
		private static extern bool ILRemoveLastID(IntPtr fullPidl);

		/// <summary>
		/// Tests whether an ITEMIDLIST structure is the parent of another ITEMIDLIST structure.
		/// </summary>
		/// <param name="pidl_absolute1">A pointer to an ITEMIDLIST (PIDL) structure that specifies the parent. This must be an absolute PIDL.</param>
		/// <param name="pidl_absolute2">A pointer to an ITEMIDLIST (PIDL) structure that specifies the child. This must be an absolute PIDL.</param>
		/// <param name="immediateParentOnly">A Boolean value that is set to TRUE to test for immediate parents of pidl2, or FALSE to test for any parents of pidl2.</param>
		/// <returns>Returns TRUE if pidl1 is a parent of pidl2. If fImmediate is set to TRUE, the function only returns TRUE if pidl1 is the immediate parent of pidl2. Otherwise, the function returns FALSE.</returns>
		[DllImport("shell32.dll")]
		[return : MarshalAs(UnmanagedType.Bool)]
		private static extern bool ILIsParent(IntPtr pidl_absolute1, IntPtr pidl_absolute2, [MarshalAs(UnmanagedType.Bool)] bool immediateParentOnly);

		// ReSharper restore InconsistentNaming

		#endregion

		#region Debugging Code

#if DEBUG
		private static int _instanceCount = 0;

		internal static int InstanceCount
		{
			get { return _instanceCount; }
		}
#endif

		#endregion
	}
}