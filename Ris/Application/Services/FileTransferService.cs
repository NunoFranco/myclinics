using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Admin.EnumerationAdmin;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Common.Utilities;
using System.Security.Permissions;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Common;
using System.IO;

namespace ClearCanvas.Ris.Application.Services.Admin.EnumerationAdmin
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IFileTransferService))]
    public class FileTransferService : ApplicationServiceBase, IFileTransferService
    {
        bool saveFile(byte[] buff, string fileExtension)
        {
            using (FileStream fs = new FileStream(System.Guid.NewGuid().ToString() + fileExtension, FileMode.CreateNew))
            {
                fs.Write(buff, 0, (int)buff.Length);
            }
            return true;
        }
        public bool UploadFile(UploadFileRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckForNullReference(request.FilesUploadList, "request.FilesUploadList ");
            foreach (var item in request.FilesUploadList )
            {
                FileInfo f = new FileInfo(item.Key);
                saveFile(item.Value, f.Extension);
                //MemoryStream ms = new MemoryStream(item.Value);
                //ms.
            }
            return true;
        }
    }
}
