using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class DicomSeries : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _studyInstanceUID = null;
		private string _seriesInstanceUID = null;
		private string _seriesDescription = null;
		private string _seriesNumber = null;
		private int _numberOfSeriesRelatedInstances = default(Int32);
		
		private PerformedProcedureStep _performedProcedureStep = null;
		
		
		#endregion

        #region Constructors

        public DicomSeries() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_studyInstanceUID);
			sb.Append(_seriesInstanceUID);
			sb.Append(_seriesDescription);
			sb.Append(_seriesNumber);
			sb.Append(_numberOfSeriesRelatedInstances);

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
		
		public virtual string StudyInstanceUID
        {
            get { return _studyInstanceUID; }
			set
			{
				OnStudyInstanceUIDChanging();
				_studyInstanceUID = value;
				OnStudyInstanceUIDChanged();
			}
        }
		partial void OnStudyInstanceUIDChanging();
		partial void OnStudyInstanceUIDChanged();
		
		public virtual string SeriesInstanceUID
        {
            get { return _seriesInstanceUID; }
			set
			{
				OnSeriesInstanceUIDChanging();
				_seriesInstanceUID = value;
				OnSeriesInstanceUIDChanged();
			}
        }
		partial void OnSeriesInstanceUIDChanging();
		partial void OnSeriesInstanceUIDChanged();
		
		public virtual string SeriesDescription
        {
            get { return _seriesDescription; }
			set
			{
				OnSeriesDescriptionChanging();
				_seriesDescription = value;
				OnSeriesDescriptionChanged();
			}
        }
		partial void OnSeriesDescriptionChanging();
		partial void OnSeriesDescriptionChanged();
		
		public virtual string SeriesNumber
        {
            get { return _seriesNumber; }
			set
			{
				OnSeriesNumberChanging();
				_seriesNumber = value;
				OnSeriesNumberChanged();
			}
        }
		partial void OnSeriesNumberChanging();
		partial void OnSeriesNumberChanged();
		
		public virtual int NumberOfSeriesRelatedInstances
        {
            get { return _numberOfSeriesRelatedInstances; }
			set
			{
				OnNumberOfSeriesRelatedInstancesChanging();
				_numberOfSeriesRelatedInstances = value;
				OnNumberOfSeriesRelatedInstancesChanged();
			}
        }
		partial void OnNumberOfSeriesRelatedInstancesChanging();
		partial void OnNumberOfSeriesRelatedInstancesChanged();
		
		public virtual PerformedProcedureStep PerformedProcedureStep
        {
            get { return _performedProcedureStep; }
			set
			{
				OnPerformedProcedureStepChanging();
				_performedProcedureStep = value;
				OnPerformedProcedureStepChanged();
			}
        }
		partial void OnPerformedProcedureStepChanging();
		partial void OnPerformedProcedureStepChanged();
		
        #endregion
    }
}
