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
using System.Text;
using System.Xml;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Enterprise.Core.Imex
{
    /// <summary>
    /// Abstract base implementation of <see cref="IXmlDataImex"/>.
    /// </summary>
    public abstract class XmlDataImexBase : IXmlDataImex
    {
        /// <summary>
        /// Implements export functionality.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IExportItem> ExportCore();

        /// <summary>
        /// Implements import functionality.
        /// </summary>
        /// <param name="items"></param>
        protected abstract void ImportCore(IEnumerable<IImportItem> items, string ClinicCode);

        #region IXmlDataImex Members

        IEnumerable<IExportItem> IXmlDataImex.Export()
        {
            return ExportCore();
        }

        void IXmlDataImex.Import(IEnumerable<IImportItem> items,string cliniccode)
        {
            ImportCore(items,"");
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Writes the specified data to the specified xml writer.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="data"></param>
        protected static void Write(XmlWriter writer, object data)
        {
            JsmlSerializer.Serialize(writer, data, data.GetType().Name, false);
        }

        /// <summary>
        /// Reads an object of the specified class from the xml reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dataContractClass"></param>
        /// <returns></returns>
        protected static object Read(XmlReader reader, Type dataContractClass)
        {
            return JsmlSerializer.Deserialize(reader, dataContractClass);
        }

         #endregion
    }
}
