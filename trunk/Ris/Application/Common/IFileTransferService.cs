using System;
using System.ServiceModel;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic ;
namespace ClearCanvas.Ris.Application.Common
{
	/// <summary>
	/// Provides operations to administer DiagnosticService entities.
	/// </summary>
	[RisApplicationService]
	[ServiceContract]
    public interface  IFileTransferService
    {
        [OperationContract]
        bool UploadFile(UploadFileRequest request);
    }
    [DataContract]
    public class UploadFileRequest
    {
    //    [DataMember]
    //    string filename;

    //    [DataMember]
    //    byte[] data;
        public UploadFileRequest(Dictionary<string, byte[]> list)
        {
            FilesUploadList = list;
        }
        [DataMember]
        public Dictionary<string, byte[]> FilesUploadList;
    }
}
