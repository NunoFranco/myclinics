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
using System.Configuration;

using ClearCanvas.Common;
using ClearCanvas.Dicom;

namespace ClearCanvas.Ris.Shreds.MwlServer.ERisQueryConnector
{
	internal class DataSourceHelper
	{
		static private string _sqlServerConnectionString;

		static DataSourceHelper()
		{
			_sqlServerConnectionString = Properties.Settings.Default.ConnectionString;
		}

		public static string ConnectionString
		{
			get { return _sqlServerConnectionString; }
			set { _sqlServerConnectionString = value; }
		}

		public static string GetProcedureModalityAEMappingFragment(string modalityAETitle)
		{
			try
			{
				SqlConnection connection = new SqlConnection(_sqlServerConnectionString);
				SqlCommand command = new SqlCommand("SELECT ProcedureModalityAEMappingTable.eRisProcedureNumber\r\n" +
													"FROM ProcedureModalityAEMappingTable\r\n" +
													"WHERE ProcedureModalityAEMappingTable.ModalityAETitle = '" + modalityAETitle + "'", connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				List<string> eRisProcedureNumbers = new List<string>();
				while (reader.Read())
					eRisProcedureNumbers.Add(reader.GetString(0));

				reader.Close();
				connection.Close();

				if (eRisProcedureNumbers.Count > 0)
				{
					StringBuilder builder = new StringBuilder();
					builder.Append("(OrderTable.ProcedureCode = ");

					bool addingFirstFragment = true;

					foreach (string procedureNumber in eRisProcedureNumbers)
					{
						if (!addingFirstFragment)
						{
							builder.Append(" OR\r\nOrderTable.ProcedureCode = ");
						}
						else
						{
							addingFirstFragment = false; 
						}

						builder.Append("'");
						builder.Append(procedureNumber);
						builder.Append("'");
					}

					builder.Append(")");
					return builder.ToString();
				}
				else
				{
					return "";
				}
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Problem during database connection or operation querying database for MWL server");
				return null;

			}
		}

		public static IList<DicomMessage> GetDataReader(string query)
		{
			try
			{
				SqlConnection connection = new SqlConnection(_sqlServerConnectionString);
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				List<DicomMessage> resultsList = new List<DicomMessage>();

				while (reader.Read())
				{
					int count = reader.FieldCount;

					DicomMessage message = new DicomMessage();
					DicomAttributeCollection dataset = message.DataSet;
					DicomSequenceItem scheduledProcedureStepSequence = null;
					DicomAttributeSQ sqAttribute = null;

					for (int i = 0; i < count; ++i)
					{
						string fieldName = reader.GetName(i);
						if (fieldName.Contains("ScheduledProcedureStep_"))
						{
							if (!dataset.Contains(DicomTags.ScheduledProcedureStepSequence))
							{
								sqAttribute = new DicomAttributeSQ(DicomTags.ScheduledProcedureStepSequence);
								scheduledProcedureStepSequence = new DicomSequenceItem();
								dataset[DicomTags.ScheduledProcedureStepSequence] = sqAttribute;
							}

							string dicomAttributeName = fieldName.Replace("ScheduledProcedureStep_", "");
							if (reader.GetValue(i) is DBNull)
								scheduledProcedureStepSequence[DicomTagDictionary.GetDicomTag(dicomAttributeName).TagValue].SetStringValue("");
							else
								scheduledProcedureStepSequence[DicomTagDictionary.GetDicomTag(dicomAttributeName).TagValue].SetStringValue( (string) reader.GetString(i));
						}
						else if (fieldName.Contains("StudyInstanceUid"))
						{
							dataset[DicomTags.StudyInstanceUid].SetStringValue(DicomUid.GenerateUid().UID.ToString());
						}
						else
						{
							if (reader.GetValue(i) is DBNull)
								dataset[DicomTagDictionary.GetDicomTag(fieldName).TagValue].SetStringValue("");
							else
								dataset[DicomTagDictionary.GetDicomTag(fieldName).TagValue].SetStringValue( (string) reader.GetString(i));
						}

						// if they're not null, there's something in them
						if (scheduledProcedureStepSequence != null && sqAttribute != null && !dataset.Contains(DicomTags.ScheduledProcedureStepSequence))
						{
							sqAttribute.AddSequenceItem(scheduledProcedureStepSequence);
						}
					}

					resultsList.Add(message);
				}

				reader.Close();
				connection.Close();

				return resultsList;
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Problem during database connection or operation querying database for MWL server");
				Platform.Log(LogLevel.Error, "Connection string: " + _sqlServerConnectionString);
				return null;
			}

		}
	}
}
