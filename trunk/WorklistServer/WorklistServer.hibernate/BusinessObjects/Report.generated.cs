using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Report : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		
		private ReportStatusEnum _reportStatusEnum = null;
		
		private IList<ReportPart> _reportParts = new List<ReportPart>();
		
		#endregion

        #region Constructors

        public Report() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);

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
		
		public virtual ReportStatusEnum ReportStatusEnum
        {
            get { return _reportStatusEnum; }
			set
			{
				OnReportStatusEnumChanging();
				_reportStatusEnum = value;
				OnReportStatusEnumChanged();
			}
        }
		partial void OnReportStatusEnumChanging();
		partial void OnReportStatusEnumChanged();
		
		public virtual IList<ReportPart> ReportParts
        {
            get { return _reportParts; }
            set
			{
				OnReportPartsChanging();
				_reportParts = value;
				OnReportPartsChanged();
			}
        }
		partial void OnReportPartsChanging();
		partial void OnReportPartsChanged();
		
        #endregion
    }
}
