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
using ClearCanvas.Dicom;
using ClearCanvas.Dicom.Iod.Macros.VoiLut;

namespace ClearCanvas.Dicom.Iod.Macros
{
	/// <summary>
	/// VoiLut Macro
	/// </summary>
	/// <remarks>As defined in the DICOM Standard 2008, Part 3, Section C.11.2 (Table C.11-2b)</remarks>
	public interface IVoiLutMacro : IIodMacro
	{
		/// <summary>
		/// Gets or sets the value of VoiLutSequence in the underlying collection. Type 1C.
		/// </summary>
		VoiLutSequenceItem[] VoiLutSequence { get; set; }

		/// <summary>
		/// Gets or sets the value of WindowCenter in the underlying collection. Type 1C.
		/// </summary>
		double[] WindowCenter { get; set; }

		/// <summary>
		/// Gets or sets the value of WindowWidth in the underlying collection. Type 1C.
		/// </summary>
		double[] WindowWidth { get; set; }

		/// <summary>
		/// Gets or sets the value of WindowCenterWidthExplanation in the underlying collection. Type 3.
		/// </summary>
		string[] WindowCenterWidthExplanation { get; set; }

		/// <summary>
		/// Gets or sets the value of VoiLutFunction in the underlying collection. Type 3.
		/// </summary>
		VoiLutFunction VoiLutFunction { get; set; }

		/// <summary>
		/// Gets the number of VOI Data LUTs included in this sequence.
		/// </summary>
		long CountDataLuts { get; }

		/// <summary>
		/// Gets the number of VOI Windows included in this sequence.
		/// </summary>
		long CountWindows { get; }
	}

	/// <summary>
	/// VoiLut Macro
	/// </summary>
	/// <remarks>As defined in the DICOM Standard 2008, Part 3, Section C.11.2 (Table C.11-2b)</remarks>
	internal class VoiLutMacro : SequenceIodBase, IVoiLutMacro
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VoiLutMacro"/> class.
		/// </summary>
		public VoiLutMacro() : base() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="VoiLutMacro"/> class.
		/// </summary>
		/// <param name="dicomSequenceItem">The dicom sequence item.</param>
		public VoiLutMacro(DicomSequenceItem dicomSequenceItem) : base(dicomSequenceItem) {}

		public void InitializeAttributes() {}

		/// <summary>
		/// Gets or sets the value of VoiLutSequence in the underlying collection. Type 1C.
		/// </summary>
		public VoiLutSequenceItem[] VoiLutSequence
		{
			get
			{
				DicomAttribute dicomAttribute = base.DicomAttributeProvider[DicomTags.VoiLutSequence];
				if (dicomAttribute.IsNull || dicomAttribute.Count == 0)
				{
					return null;
				}

				VoiLutSequenceItem[] result = new VoiLutSequenceItem[dicomAttribute.Count];
				DicomSequenceItem[] items = (DicomSequenceItem[]) dicomAttribute.Values;
				for (int n = 0; n < items.Length; n++)
					result[n] = new VoiLutSequenceItem(items[n]);

				return result;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					base.DicomAttributeProvider[DicomTags.VoiLutSequence] = null;
					return;
				}

				DicomSequenceItem[] result = new DicomSequenceItem[value.Length];
				for (int n = 0; n < value.Length; n++)
					result[n] = value[n].DicomSequenceItem;

				base.DicomAttributeProvider[DicomTags.VoiLutSequence].Values = result;
			}
		}

		/// <summary>
		/// Gets or sets the value of WindowCenter in the underlying collection. Type 1C.
		/// </summary>
		public double[] WindowCenter
		{
			get
			{
				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowCenter];
				if (attribute.IsNull || attribute.IsEmpty || attribute.Count == 0)
					return null;

				double[] values = new double[attribute.Count];
				for (int n = 0; n < attribute.Count; n++)
					values[n] = attribute.GetFloat64(n, 0);
				return values;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					base.DicomAttributeProvider[DicomTags.WindowCenter] = null;
					return;
				}

				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowCenter];
				for (int n = value.Length - 1; n >= 0; n--)
					attribute.SetFloat64(n, value[n]);
			}
		}

		/// <summary>
		/// Gets or sets the value of WindowWidth in the underlying collection. Type 1C.
		/// </summary>
		public double[] WindowWidth
		{
			get
			{
				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowWidth];
				if (attribute.IsNull || attribute.IsEmpty || attribute.Count == 0)
					return null;

				double[] values = new double[attribute.Count];
				for (int n = 0; n < attribute.Count; n++)
					values[n] = attribute.GetFloat64(n, 0);
				return values;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					base.DicomAttributeProvider[DicomTags.WindowWidth] = null;
					return;
				}

				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowWidth];
				for (int n = value.Length - 1; n >= 0; n--)
					attribute.SetFloat64(n, value[n]);
			}
		}

		/// <summary>
		/// Gets or sets the value of WindowCenterWidthExplanation in the underlying collection. Type 3.
		/// </summary>
		public string[] WindowCenterWidthExplanation
		{
			get
			{
				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowCenterWidthExplanation];
				if (attribute.IsNull || attribute.IsEmpty || attribute.Count == 0)
					return null;
				return (string[]) attribute.Values;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					base.DicomAttributeProvider[DicomTags.WindowCenterWidthExplanation] = null;
					return;
				}
				base.DicomAttributeProvider[DicomTags.WindowCenterWidthExplanation].Values = value;
			}
		}

		/// <summary>
		/// Gets or sets the value of VoiLutFunction in the underlying collection. Type 3.
		/// </summary>
		public VoiLutFunction VoiLutFunction
		{
			get { return ParseEnum(base.DicomAttributeProvider[DicomTags.VoiLutFunction].GetString(0, string.Empty), VoiLutFunction.None); }
			set
			{
				if (value == VoiLutFunction.None)
				{
					base.DicomAttributeProvider[DicomTags.VoiLutFunction] = null;
					return;
				}
				SetAttributeFromEnum(base.DicomAttributeProvider[DicomTags.VoiLutFunction], value);
			}
		}

		/// <summary>
		/// Gets the number of VOI Data LUTs included in this sequence.
		/// </summary>
		public long CountDataLuts
		{
			get
			{
				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.VoiLutSequence];
				if (attribute.IsNull || attribute.IsEmpty)
					return 0;
				return attribute.Count;
			}
		}

		/// <summary>
		/// Gets the number of VOI Windows included in this sequence.
		/// </summary>
		public long CountWindows
		{
			get
			{
				DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.WindowCenter];
				if (attribute.IsNull || attribute.IsEmpty)
					return 0;
				return attribute.Count;
			}
		}
	}

	namespace VoiLut
	{
		/// <summary>
		/// VoiLut Sequence
		/// </summary>
		/// <remarks>As defined in the DICOM Standard 2008, Part 3, Section C.11.2 (Table C.11-2b)</remarks>
		public class VoiLutSequenceItem : SequenceIodBase
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="VoiLutSequenceItem"/> class.
			/// </summary>
			public VoiLutSequenceItem() : base() {}

			/// <summary>
			/// Initializes a new instance of the <see cref="VoiLutSequenceItem"/> class.
			/// </summary>
			/// <param name="dicomSequenceItem">The dicom sequence item.</param>
			public VoiLutSequenceItem(DicomSequenceItem dicomSequenceItem) : base(dicomSequenceItem) {}

			/// <summary>
			/// Gets or sets the value of LutDescriptor in the underlying collection. Type 1.
			/// </summary>
			public int[] LutDescriptor
			{
				get
				{
					int[] result = new int[3];
					if (base.DicomAttributeProvider[DicomTags.LutDescriptor].TryGetInt32(0, out result[0]))
						if (base.DicomAttributeProvider[DicomTags.LutDescriptor].TryGetInt32(1, out result[1]))
							if (base.DicomAttributeProvider[DicomTags.LutDescriptor].TryGetInt32(2, out result[2]))
								return result;
					return null;
				}
				set
				{
					if (value == null || value.Length != 3)
						throw new ArgumentNullException("value", "LutDescriptor is Type 1 Required.");
					base.DicomAttributeProvider[DicomTags.LutDescriptor].SetInt32(0, value[0]);
					base.DicomAttributeProvider[DicomTags.LutDescriptor].SetInt32(1, value[1]);
					base.DicomAttributeProvider[DicomTags.LutDescriptor].SetInt32(2, value[2]);
				}
			}

			/// <summary>
			/// Gets or sets the value of LutExplanation in the underlying collection. Type 3.
			/// </summary>
			public string LutExplanation
			{
				get { return base.DicomAttributeProvider[DicomTags.LutExplanation].GetString(0, string.Empty); }
				set
				{
					if (string.IsNullOrEmpty(value))
					{
						base.DicomAttributeProvider[DicomTags.LutExplanation] = null;
						return;
					}
					base.DicomAttributeProvider[DicomTags.LutExplanation].SetString(0, value);
				}
			}

			/// <summary>
			/// Gets or sets the value of LutData in the underlying collection. Type 1C.
			/// </summary>
			public ushort[] LutData
			{
				get
				{
					DicomAttribute attribute = base.DicomAttributeProvider[DicomTags.LutData];
					if (attribute.IsNull || attribute.IsEmpty || attribute.Count == 0)
						return null;
					return (ushort[])attribute.Values;
				}
				set
				{
					if (value == null || value.Length == 0)
					{
						base.DicomAttributeProvider[DicomTags.LutData] = null;
						return;
					}
					base.DicomAttributeProvider[DicomTags.LutData].Values = value;
				}
			}
		}

		/// <summary>
		/// Enumerated values for the <see cref="DicomTags.VoiLutFunction"/> attribute describing
		/// a VOI LUT function to apply to the <see cref="IVoiLutMacro.WindowCenter"/> and <see cref="IVoiLutMacro.WindowWidth"/>.
		/// </summary>
		/// <remarks>As defined in the DICOM Standard 2008, Part 3, Section C.11.2 (Table C.11-2b)</remarks>
		public enum VoiLutFunction {
			Linear,
			Sigmoid,

			/// <summary>
			/// Represents the null value, which is equivalent to the unknown status.
			/// </summary>
			None
		}
	}
}
