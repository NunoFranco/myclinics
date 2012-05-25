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

namespace ClearCanvas.Controls.WinForms
{
	partial class Native
	{
		[Flags]
		public enum SFGAO : uint
		{
			SFGAO_CANCOPY = 0x1, // Objects can be copied  (DROPEFFECT_COPY)
			SFGAO_CANMOVE = 0x2, // Objects can be moved   (DROPEFFECT_MOVE)
			SFGAO_CANLINK = 0x4, // Objects can be linked  (DROPEFFECT_LINK)
			SFGAO_STORAGE = 0x00000008, // Supports BindToObject(IID_IStorage)
			SFGAO_CANRENAME = 0x00000010, // Objects can be renamed
			SFGAO_CANDELETE = 0x00000020, // Objects can be deleted
			SFGAO_HASPROPSHEET = 0x00000040, // Objects have property sheets
			SFGAO_DROPTARGET = 0x00000100, // Objects are drop target
			SFGAO_CAPABILITYMASK = 0x00000177,
			SFGAO_ENCRYPTED = 0x00002000, // Object is encrypted (use alt color)
			SFGAO_ISSLOW = 0x00004000, // 'Slow' object
			SFGAO_GHOSTED = 0x00008000, // Ghosted icon
			SFGAO_LINK = 0x00010000, // Shortcut (link)
			SFGAO_SHARE = 0x00020000, // Shared
			SFGAO_READONLY = 0x00040000, // Read-only
			SFGAO_HIDDEN = 0x00080000, // Hidden object
			SFGAO_DISPLAYATTRMASK = 0x000FC000,
			SFGAO_FILESYSANCESTOR = 0x10000000, // May contain children with SFGAO_FILESYSTEM
			SFGAO_FOLDER = 0x20000000, // Support BindToObject(IID_IShellFolder)
			SFGAO_FILESYSTEM = 0x40000000, // Is a win32 file system object (file/folder/root)
			SFGAO_HASSUBFOLDER = 0x80000000, // May contain children with SFGAO_FOLDER
			SFGAO_CONTENTSMASK = 0x80000000,
			SFGAO_VALIDATE = 0x01000000, // Invalidate cached information
			SFGAO_REMOVABLE = 0x02000000, // Is this removeable media?
			SFGAO_COMPRESSED = 0x04000000, // Object is compressed (use alt color)
			SFGAO_BROWSABLE = 0x08000000, // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
			SFGAO_NONENUMERATED = 0x00100000, // Is a non-enumerated object
			SFGAO_NEWCONTENT = 0x00200000, // Should show bold in explorer tree
			SFGAO_CANMONIKER = 0x00400000, // Defunct
			SFGAO_HASSTORAGE = 0x00400000, // Defunct
			SFGAO_STREAM = 0x00400000, // Supports BindToObject(IID_IStream)
			SFGAO_STORAGEANCESTOR = 0x00800000, // May contain children with SFGAO_STORAGE or SFGAO_STREAM
			SFGAO_STORAGECAPMASK = 0x70C50008, // For determining storage capabilities, ie for open/save semantics
		}
	}
}