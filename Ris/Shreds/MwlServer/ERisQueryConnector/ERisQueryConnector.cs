#region License

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
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using ClearCanvas.Common;
using ClearCanvas.Dicom;

namespace ClearCanvas.Ris.Shreds.MwlServer.ERisQueryConnector
{
	class SBHelper
	{
		protected StringBuilder _stringBuilder;
		protected bool _addingFirstFragment = true;
		protected string _initialFragment;

		public SBHelper(StringBuilder stringBuilder)
		{
			_stringBuilder = stringBuilder;
		}

		public SBHelper(StringBuilder stringBuilder, string initial) : this(stringBuilder)
		{
			_initialFragment = initial;
		}

		public virtual void Add(string fragment)
		{
			if (-1 == _stringBuilder.ToString().IndexOf(fragment))
			{
				if (!_addingFirstFragment)
					_stringBuilder.Append(",\r\n");
				else
				{
					_stringBuilder.Append(_initialFragment);
					_addingFirstFragment = false;
				}

				_stringBuilder.Append(fragment);
			}
		}

		public StringBuilder SBObject
		{
			get { return _stringBuilder; }
		}
	}

	class JoinSBHelper : SBHelper
	{
		public JoinSBHelper(StringBuilder stringBuilder) : base(stringBuilder) { }
		public JoinSBHelper(StringBuilder stringBuilder, string initial): base (stringBuilder, initial) {}

		public override void Add(string fragment)
		{
			if (-1 == _stringBuilder.ToString().IndexOf(fragment))
			{
				_stringBuilder.Append("\r\nLEFT JOIN ");
				_stringBuilder.Append(fragment);
			}			
		}
	}

	class WhereSBHelper : SBHelper
	{
		public WhereSBHelper(StringBuilder stringBuilder) : base(stringBuilder) { }
		public WhereSBHelper(StringBuilder stringBuilder, string initial) : base(stringBuilder, initial) { }

		public override void Add(string fragment)
		{
			if (-1 == _stringBuilder.ToString().IndexOf(fragment))
			{
				if (!_addingFirstFragment)
					_stringBuilder.Append(" AND\r\n");
				else
				{
					_stringBuilder.Append(_initialFragment);
					_addingFirstFragment = false;
				}

				_stringBuilder.Append(fragment);
			}
		}
	}

	[ExtensionOf(typeof(MwlServerExtensionPoint))]
	public class ERisQueryConnector : IQueryConnector
	{
		private delegate void SelectStatementFragment(SBHelper selectorBuilder, SBHelper fromBuilder, 
			SBHelper joinBuilder, SBHelper whereBuilder, string attributeValue, string callingAE);
		static private Dictionary<uint, SelectStatementFragment> Dicom2Selector = new Dictionary<uint, SelectStatementFragment>();

		static private DateTime GetDateFromDicomDate(string dateValue)
		{
			string year = dateValue.Substring(0, 4);
			string month = dateValue.Substring(4, 2);
			string day = dateValue.Substring(6, 2);

			return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
		}

		//
		//
		// Convention used: OrderTable is the left-hand table, and all joins are relative to it
		//
		//
		static ERisQueryConnector()
		{
			Dicom2Selector[DicomTags.PatientsName] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{ 
					sb.Add("OrderTable.PatientSurname + '^' + OrderTable.PatientGivenName as PatientsName");
					fb.Add("OrderTable");

					if (null != attributeValue)
					{
						attributeValue = attributeValue.Replace('*', '%');
						attributeValue = attributeValue.Replace("'", "''");

						string[] parts = attributeValue.Split('^');
						if (parts.Length > 0)
						{
							string matching = String.Format("OrderTable.PatientSurname LIKE '{0}'", parts[0]);
							wb.Add(matching);
						}
						if (parts.Length > 1)
						{
							string matching = String.Format("OrderTable.PatientGivenName LIKE '{0}'", parts[1]);
							wb.Add(matching);
						}
					}
				};
			Dicom2Selector[DicomTags.PatientId] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{
					sb.Add("OrderTable.PatientMRN + ' ' + OrderTable.Site as PatientId");
					fb.Add("OrderTable");

					if (null != attributeValue)
					{
						attributeValue = attributeValue.Replace('*', '%');

						string matching = String.Format("OrderTable.PatientMRN LIKE '{0}'", attributeValue);
						wb.Add(matching);
					}
				};
			Dicom2Selector[DicomTags.PatientsBirthDate] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{
					sb.Add("STR(DATEPART(yyyy,PatientTable.DateOfBirth),4) + " +
						   "RIGHT('00000000' + CAST(DATEPART(mm,PatientTable.DateOfBirth) as VARCHAR(8)),2) + " +
					       "RIGHT('00000000' + CAST(DATEPART(dd,PatientTable.DateOfBirth) as VARCHAR(8)), 2) as PatientsBirthDate");
					jb.Add("PatientTable on (PatientTable.PatientID = OrderTable.PatientID)");
				};
			Dicom2Selector[DicomTags.PatientsSex] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{
					sb.Add("PatientTable.Sex as PatientsSex");
					jb.Add("PatientTable on (PatientTable.PatientID = OrderTable.PatientID)");
				};
			Dicom2Selector[DicomTags.AdmissionId] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{
					sb.Add("OrderTable.VisitNumber as AdmissionId");
					fb.Add("OrderTable");
				};
			Dicom2Selector[DicomTags.AccessionNumber] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE) 
				{
					sb.Add("OrderTable.AccessionNumber as AccessionNumber");
					fb.Add("OrderTable");
				};
			Dicom2Selector[DicomTags.ReferringPhysiciansName] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("PhysicianTable.Surname + '^' + PhysicianTable.GivenName as ReferringPhysiciansName");
					jb.Add("PhysicianTable on (PhysicianTable.PhysicianID = OrderTable.OrderingMDID)");
				};

			Dicom2Selector[DicomTags.StudyInstanceUid] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					// since we need to generate one UID per result, we'll just put in a placeholder for now
					// and then generate them when we're sending back the find results
					sb.Add("'' as StudyInstanceUid");					
				};
			Dicom2Selector[DicomTags.CurrentPatientLocation] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("OrderTable.PatientLocation as CurrentPatientLocation");
				};
			Dicom2Selector[DicomTags.Modality] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("CASE OrderTable.Modality\r\n" +
						   "  WHEN 'General Radiography' THEN 'CR'\r\n" +
						   "  WHEN 'Nuclear Medicine' THEN 'NM'\r\n" +
					       "  WHEN 'MRI' THEN 'MR'\r\n" +
					       "  WHEN 'Angiography' THEN 'XA'\r\n" +
					       "  WHEN 'Breast Imaging' THEN 'MG'\r\n" +
					       "  WHEN 'CT' THEN 'CT'\r\n" +
					       "  WHEN 'GI/GU' THEN 'CR'\r\n" +
					       "  WHEN 'Ultrasound' THEN 'US'\r\n" +
						   "END as Modality");

					if (null != attributeValue)
					{
						attributeValue = attributeValue.Replace('*', '%');

						switch (attributeValue)
						{
							case "CR":
								wb.Add("(OrderTable.Modality = 'General Radiography' OR OrderTable.Modality = 'CR')");
								break;
							case "NM":
								wb.Add("OrderTable.Modality = 'Nuclear Medicine'");
								break;
							case "MR":
								wb.Add("OrderTable.Modality = 'MRI'");
								break;
							case "XA":
								wb.Add("OrderTable.Modality = 'Angiography'");
								break;
							case "MG":
								wb.Add("OrderTable.Modality = 'Breast Imaging'");
								break;
							case "CT":
								wb.Add("OrderTable.Modality = 'CT'");
								break;
							case "US":
								wb.Add("OrderTable.Modality = 'Ultrasound'");
								break;
						}
					}
				};
			Dicom2Selector[DicomTags.ScheduledProcedureStepStartDate] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("STR(DATEPART(yyyy,OrderTable.ScheduledDateTime),4) + " +
						   "RIGHT('00000000' + CAST(DATEPART(mm,OrderTable.ScheduledDateTime) as VARCHAR(8)),2) + " +
					       "RIGHT('00000000' + CAST(DATEPART(dd,OrderTable.ScheduledDateTime) as VARCHAR(8)), 2) as ScheduledProcedureStep_ScheduledProcedureStepStartDate");

					if (null != attributeValue)
					{
						if (attributeValue.Contains("-"))
						{
							int index = attributeValue.IndexOf('-');

							if (0 == index)	// right bound only exists
							{
								DateTime rightBound = GetDateFromDicomDate(attributeValue.Substring(1));
								wb.Add(string.Format("OrderTable.ScheduledDateTime <= '{0:yyyy-MM-dd}'", rightBound));
							}
							else if (attributeValue.Length - 1 == index) // left bound only exists
							{
								DateTime leftBound = GetDateFromDicomDate(attributeValue.Substring(0, 8));
								wb.Add(string.Format("OrderTable.ScheduledDateTime >= '{0:yyyy-MM-dd}'", leftBound));
							}
							else // left and right bound both
							{
								string[] parts = attributeValue.Split('-');

								string year = parts[0].Substring(0, 4);
								string month = parts[0].Substring(4, 2);
								string day = parts[0].Substring(6, 2);

								DateTime leftBound = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

								year = parts[1].Substring(0, 4);
								month = parts[1].Substring(4, 2);
								day = parts[1].Substring(6, 2);

								DateTime rightBound = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
								rightBound = rightBound.AddDays(1);

								wb.Add(string.Format("OrderTable.ScheduledDateTime >= '{0:yyyy-MM-dd}' AND " +
													 "OrderTable.ScheduledDateTime <= '{1:yyyy-MM-dd}'",
													 leftBound,
													 rightBound));
							}
						}
						else
						{
							string year = attributeValue.Substring(0, 4);
							string month = attributeValue.Substring(4, 2);
							string day = attributeValue.Substring(6, 2);

							DateTime leftBound = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
							DateTime rightBound = leftBound.AddDays(1);
														
							wb.Add(string.Format("OrderTable.ScheduledDateTime >= '{0:yyyy-MM-dd}' AND " +
								                 "OrderTable.ScheduledDateTime < '{1:yyyy-MM-dd}'",
												 leftBound,
												 rightBound));
						}
					}
				};
			Dicom2Selector[DicomTags.ScheduledProcedureStepStartTime] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("RIGHT('00000000' + CAST(DATEPART(hh,OrderTable.ScheduledDateTime) as VARCHAR(8)),2) + " +
						   "RIGHT('00000000' + CAST(DATEPART(mi,OrderTable.ScheduledDateTime) as VARCHAR(8)),2) + " +
						   "RIGHT('00000000' + CAST(DATEPART(ss,OrderTable.ScheduledDateTime) as VARCHAR(8)), 2) as ScheduledProcedureStep_ScheduledProcedureStepStartTime");
				};
			Dicom2Selector[DicomTags.ScheduledProcedureStepDescription] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("CASE OrderTable.Portable \r\n" +
						   "  WHEN 1 THEN OrderTable.ProcedureName + ' Port.' \r\n" +
						   "ELSE OrderTable.ProcedureName \r\n" +
						   "END as ScheduledProcedureStep_ScheduledProcedureStepDescription");
				};
			Dicom2Selector[DicomTags.ScheduledProcedureStepId] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("LEFT(OrderTable.FillerOrderNumber,16) as ScheduledProcedureStep_ScheduledProcedureStepId");
				};
			Dicom2Selector[DicomTags.ScheduledStationAeTitle] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("'" + attributeValue + "' as ScheduledProcedureStep_ScheduledStationAeTitle");
				};
			Dicom2Selector[DicomTags.FillerOrderNumberImagingServiceRequest] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("OrderTable.FillerOrderNumber as FillerOrderNumberImagingServiceRequest");
				};
			Dicom2Selector[DicomTags.InstitutionName] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("OrderTable.Site as InstitutionName");
				};

			Dicom2Selector[DicomTags.RequestedProcedureId] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("LEFT(OrderTable.FillerOrderNumber, 16) as RequestedProcedureId");
				};
			Dicom2Selector[DicomTags.RequestedProcedureDescription] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("CASE OrderTable.Portable \r\n" +
						   "  WHEN 1 THEN OrderTable.ProcedureName + ' Port.' \r\n" +
						   "ELSE OrderTable.ProcedureName \r\n" +
						   "END as RequestedProcedureDescription");
				};
			Dicom2Selector[DicomTags.ScheduledPerformingPhysiciansName] = delegate(SBHelper sb, SBHelper fb, SBHelper jb, SBHelper wb, string attributeValue, string callingAE)
				{
					sb.Add("'' as ScheduledProcedureStep_ScheduledPerformingPhysiciansName");
				};
		}


		#region IQueryConnector Members

		public IList<DicomMessage> Query(DicomMessage message, string callingAE)
		{
			IList<DicomAttributeCollection> queryAttributeCollections = new List<DicomAttributeCollection>();

			queryAttributeCollections.Add(message.DataSet);

			if (message.DataSet.Contains(DicomTags.ScheduledProcedureStepSequence))
			{
				DicomSequenceItem[] items = (DicomSequenceItem[])message.DataSet.GetAttribute(DicomTags.ScheduledProcedureStepSequence).Values;

				// there should only be one
				queryAttributeCollections.Add(items[0]);
			}

			string queryString = BuildQuery(callingAE, queryAttributeCollections);

			Platform.Log(LogLevel.Debug, queryString);

			return DataSourceHelper.GetDataReader(queryString);
		}
		#endregion

		private string BuildQuery(string callingAE, IList<DicomAttributeCollection> queryAttributeCollections)
		{
			SBHelper selectorBuilder = new SBHelper(new StringBuilder(), "SELECT ");
			SBHelper fromBuilder = new SBHelper(new StringBuilder(), "\r\nFROM ");
			SBHelper joinBuilder = new JoinSBHelper(new StringBuilder());
			SBHelper whereBuilder = new WhereSBHelper(new StringBuilder(), "\r\nWHERE ");

			foreach (DicomAttributeCollection collection in queryAttributeCollections)
			{
				foreach (DicomAttribute attribute in collection)
				{
					if (Dicom2Selector.ContainsKey(attribute.Tag.TagValue))
					{
						string attributeValue = null;
						
						if (!attribute.IsEmpty && !attribute.IsNull)
							attributeValue = attribute.GetString(0, "");

						(Dicom2Selector[attribute.Tag.TagValue])(selectorBuilder, fromBuilder, joinBuilder, whereBuilder, attributeValue, callingAE);
					}
				}
			}

			whereBuilder.Add("OrderTable.Performedstatus = 'Scheduled'");

			if (Properties.Settings.Default.ProcedureModalityAEMappingMode)
			{
				whereBuilder.Add(DataSourceHelper.GetProcedureModalityAEMappingFragment(callingAE));
			}

			StringBuilder query = new StringBuilder();
			if (selectorBuilder.SBObject.Length > 0) query.Append(selectorBuilder.SBObject.ToString());
			if (fromBuilder.SBObject.Length > 0) query.Append(fromBuilder.SBObject.ToString());
			if (joinBuilder.SBObject.Length > 0) query.Append(joinBuilder.SBObject.ToString());
			if (whereBuilder.SBObject.Length > 0) query.Append(whereBuilder.SBObject.ToString());

			return query.ToString();
		}
	}
}
