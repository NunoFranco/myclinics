using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ConfigurationDocumentBody : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _documentText = null;
		
		
		
		#endregion

        #region Constructors

        public ConfigurationDocumentBody() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_documentText);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual int Version
        {
            get { return _version; }
			set
			{
				OnVersionChanging();
				_version = value;
				OnVersionChanged();
			}
        }
		partial void OnVersionChanging();
		partial void OnVersionChanged();
		
		public virtual string DocumentText
        {
            get { return _documentText; }
			set
			{
				OnDocumentTextChanging();
				_documentText = value;
				OnDocumentTextChanged();
			}
        }
		partial void OnDocumentTextChanging();
		partial void OnDocumentTextChanged();
		
        #endregion
    }
}
