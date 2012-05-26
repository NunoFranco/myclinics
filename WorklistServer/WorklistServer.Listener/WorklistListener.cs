using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Dicom;
using ClearCanvas.Common;
using ClearCanvas.Common.Shreds;
using ClearCanvas.Dicom.Network;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Reflection;
namespace WorklistServer.Listener
{
    public static class WORKLISTMEMBER
    {
        public static string PATIENTNAME = "PatientName";
        public static string SEX = "SEX";
        public static string PATIENTID = "PatientID";
        public static string ACCESSIONNUMBER = "AccessionNumber";
        public static string SCHEDULE = "SCHEDULE";
        public static string INDICATION = "Indication";
        public static string MODALITY = "Modality";
        public static string ProcedureID = "ProcedureID";
        public static string Birthday = "Birthday";
        public static string Sex = "Sex";
    }

    public class WorklistListener : IDicomServerHandler
    {
        private ServerAssociationParameters _parms;
        public string _AE;
        public int _Port;
        public IPEndPoint _Server;
        public string _ConnectionString;
        private void GetServer()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    _Server = new IPEndPoint(address, _Port);
                    break;

                }
            }
        }
        public void SetServerParams()
        {

            _parms = new ServerAssociationParameters(_AE, _Server);

            _parms.AddPresentationContext(1, SopClass.VerificationSopClass);
            _parms.AddTransferSyntax(1, TransferSyntax.ExplicitVrLittleEndian);
            _parms.AddTransferSyntax(1, TransferSyntax.ImplicitVrLittleEndian);

            _parms.AddPresentationContext(2, SopClass.ModalityWorklistInformationModelFind);
            _parms.AddTransferSyntax(2, TransferSyntax.ExplicitVrLittleEndian);
            _parms.AddTransferSyntax(2, TransferSyntax.ImplicitVrLittleEndian);
            _parms.AddTransferSyntax(2, TransferSyntax.ExplicitVrBigEndian);

        }
        public void CopyDataSet(DicomAttributeCollection Source, DicomAttributeCollection Desc)
        {
            FieldInfo[] fieldInfos;
            fieldInfos = typeof(DicomTags).GetFields();

            DicomTags t = new DicomTags();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                DicomAttribute tag = Source[(uint)fieldInfo.GetValue(t)];
                if (!tag.IsNull && !tag.IsEmpty)
                    Desc[(uint)fieldInfo.GetValue(t)] = Source[(uint)fieldInfo.GetValue(t)];
            }

        }
        public WorklistListener(string AE, int Port, string connectionString)
        {
            _AE = AE;
            _Port = Port;
            _ConnectionString = connectionString;
            GetServer();
            SetServerParams();
        }
        private IDicomServerHandler StartAssociation(DicomServer server, ServerAssociationParameters assoc)
        {
            return this;
        }

        #region IDicomServerHandler Members

        public void OnReceiveAssociateRequest(DicomServer server, ServerAssociationParameters association)
        {
            //if (_delayAssociationAccept.Checked)
            //    Thread.Sleep(TimeSpan.FromSeconds(35));

            //if (_rejectAssociation.Checked)
            //    server.SendAssociateReject(DicomRejectResult.Permanent, DicomRejectSource.ServiceUser, DicomRejectReason.CallingAENotRecognized);
            //else
            server.SendAssociateAccept(association);
        }

        public void OnReceiveRequestMessage(DicomServer server, ServerAssociationParameters association, byte presentationID, ClearCanvas.Dicom.DicomMessage message)
        {

            foreach (byte pcid in association.GetPresentationContextIDs())
            {
                DicomPresContext context = association.GetPresentationContext(pcid);
                if (context.Result == DicomPresContextResult.Accept)
                {
                    if (context.AbstractSyntax == SopClass.ModalityWorklistInformationModelFind)
                    {

                        DAO.DAO db = new WorklistServer.DAO.DAO(_ConnectionString);
                        string modalities = message.DataSet[DicomTags.Modality];
                        string scheduledDate = message.DataSet[DicomTags.ScheduledProcedureStepStartDate];
                        string studyuidy = message.DataSet[DicomTags.StudyInstanceUid];
                        if (modalities == "" || scheduledDate == "")
                        {
                            DicomSequenceItem[] tmp1 = (DicomSequenceItem[])message.DataSet[DicomTags.ScheduledProcedureStepSequence].Values;
                            if (tmp1 != null && tmp1.Length > 0)
                            {
                                modalities = modalities == "" ? tmp1[0][DicomTags.Modality] : modalities;
                                scheduledDate = scheduledDate == "" ? tmp1[0][DicomTags.ScheduledProcedureStepStartDate] : scheduledDate;
                            }
                        }
                        if (studyuidy == "")
                        {
                            DicomSequenceItem[] tmp1 = (DicomSequenceItem[])message.DataSet[DicomTags.ScheduledStepAttributesSequence].Values;
                            if (tmp1 != null && tmp1.Length > 0)
                            {
                                studyuidy = studyuidy == "" ? tmp1[0][DicomTags.StudyInstanceUid] : studyuidy;
                            }
                        }
                        db.parameters.Add("Mod", modalities);
                        db.parameters.Add("PatientName", message.DataSet[DicomTags.PatientsName]);
                        db.parameters.Add("AccessionNumber", message.DataSet[DicomTags.AccessionNumber]);
                        db.parameters.Add("PatientID", message.DataSet[DicomTags.PatientId]);

                        DataTable dt = db.LoadWorklist();
                        DicomMessage response = new DicomMessage();

                        CopyDataSet(message.DataSet, response.DataSet);
                        DicomAttributeSQ attribute = (DicomAttributeSQ)message.DataSet[4194560];

                        foreach (DataRow row in dt.Rows)
                        {
                            response.DataSet[DicomTags.PatientId].SetStringValue(row[WORKLISTMEMBER.PATIENTID].ToString());
                            response.DataSet[DicomTags.PatientsName].SetStringValue(row[WORKLISTMEMBER.PATIENTNAME].ToString());
                            response.DataSet[DicomTags.AccessionNumber].SetStringValue(row[WORKLISTMEMBER.ACCESSIONNUMBER].ToString());
                            response.DataSet[DicomTags.PatientId].SetStringValue(row[WORKLISTMEMBER.PATIENTID].ToString());
                            response.DataSet[DicomTags.RequestedProcedureId].SetStringValue(row[WORKLISTMEMBER.ProcedureID].ToString());
                            response.DataSet[DicomTags.StudyInstanceUid].SetStringValue(studyuidy);

                            modalities = Convert.ToString(row[WORKLISTMEMBER.MODALITY]);
                            DateTime ScheduledProcedureStepStartDate = Convert.ToDateTime(row[WORKLISTMEMBER.SCHEDULE]);
                            response.DataSet[DicomTags.Modality].SetStringValue(modalities);
                            response.DataSet[DicomTags.ScheduledProcedureStepStartDate].SetStringValue(ScheduledProcedureStepStartDate.ToString("yyyMMdd"));

                            DateTime? birth = null;
                            if (row[WORKLISTMEMBER.Birthday] != null)
                                birth = Convert.ToDateTime(row[WORKLISTMEMBER.Birthday]);
                            string strbirth = birth == null ? "" : birth.Value.Date.ToString("yyyyMMdd");
                            response.DataSet[DicomTags.PatientsBirthDate].SetStringValue(strbirth);
                            response.DataSet[DicomTags.PatientsSex].SetStringValue(row[WORKLISTMEMBER.SEX].ToString());

                            DicomSequenceItem sitem = new DicomSequenceItem();
                            DicomSequenceItem [] sitems=(DicomSequenceItem [])response.DataSet[4194560].Values;
                            if (sitems != null && sitems.Length > 0)//if there are sequence item get from request message though CopyDataSet(source,des)
                            {
                                sitems[0][DicomTags.Modality].SetStringValue(modalities);
                                sitems[0][DicomTags.ScheduledProcedureStepStartDate].SetStringValue(ScheduledProcedureStepStartDate.Date.ToString("yyyMMdd"));
                            }
                            else // does not have any Sequence item
                            {
                                sitem[DicomTags.Modality].SetStringValue(modalities);
                                sitem[DicomTags.ScheduledProcedureStepStartDate].SetStringValue(ScheduledProcedureStepStartDate.Date.ToString("yyyMMdd"));
                                response.DataSet[4194560].AddSequenceItem(sitem);
                            }

                            server.SendCFindResponse(presentationID, message.MessageId, response, DicomStatuses.Pending);
                        }
                        DicomMessage finalResponse = new DicomMessage();
                        server.SendCFindResponse(presentationID, message.MessageId, finalResponse, DicomStatuses.Success);
                    }
                    else if (context.AbstractSyntax == SopClass.VerificationSopClass)
                    {
                        server.SendCEchoResponse(presentationID, message.MessageId, DicomStatuses.Success);
                    }
                }
            }
        }

        public void OnReceiveResponseMessage(DicomServer server, ServerAssociationParameters association, byte presentationID, ClearCanvas.Dicom.DicomMessage message)
        {
            server.SendAssociateAbort(DicomAbortSource.ServiceUser, DicomAbortReason.UnexpectedPDU);
        }

        public void OnReceiveReleaseRequest(DicomServer server, ServerAssociationParameters association)
        {
            //if (_delayAssociationRelease.Checked)
            //    Thread.Sleep(TimeSpan.FromSeconds(35));
        }

        public void OnReceiveAbort(DicomServer server, ServerAssociationParameters association, DicomAbortSource source, DicomAbortReason reason)
        {
        }

        public void OnNetworkError(DicomServer server, ServerAssociationParameters association, Exception e)
        {
        }

        public void OnDimseTimeout(DicomServer server, ServerAssociationParameters association)
        {
        }

        #endregion
        public void StartListening()
        {
            if (_parms == null)
            {
                SetServerParams();
            }
            DicomServer.StartListening(_parms, StartAssociation);
            Platform.Log(LogLevel.Info, _ConnectionString);
        }
        public void StopListening()
        {
            DicomServer.StopListening(_parms);
            _parms = null;
        }
    }
}


