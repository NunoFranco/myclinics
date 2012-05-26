using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Staff : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _id = String.Empty;
		private string _familyName = String.Empty;
		private string _givenName = String.Empty;
		private string _middleName = null;
		private string _prefix = null;
		private string _suffix = null;
		private string _degree = null;
		private string _title = null;
		private string _licenseNumber = null;
		private string _billingNumber = null;
		private string _userName = null;
		private bool _deactivated = default(Boolean);
		
		private SexEnum _sexEnum = null;
		private StaffTypeEnum _staffTypeEnum = null;
		
		private IList<NotePosting> _notePostings1 = new List<NotePosting>();
		private IList<OrderAttachment> _orderAttachments = new List<OrderAttachment>();
		private IList<PatientAttachment> _patientAttachments = new List<PatientAttachment>();
		private IList<Note> _notes = new List<Note>();
		private IList<PatientNote> _patientNotes = new List<PatientNote>();
		private IList<Protocol> _protocols1 = new List<Protocol>();
		private IList<Order> _orders1 = new List<Order>();
		private IList<Order> _orders2 = new List<Order>();
		private IList<ReportPart> _reportParts1 = new List<ReportPart>();
		private IList<Worklist> _worklists = new List<Worklist>();
		private IList<ProcedureStep> _procedureSteps1 = new List<ProcedureStep>();
		private IList<PerformedProcedureStep> _performedProcedureSteps = new List<PerformedProcedureStep>();
		private IList<NotePosting> _notePostings2 = new List<NotePosting>();
		private IList<ProcedureStep> _procedureSteps2 = new List<ProcedureStep>();
		private IList<CannedText> _cannedTexts = new List<CannedText>();
		private IList<StaffTelephoneNumber> _staffTelephoneNumbers = new List<StaffTelephoneNumber>();
		private IList<StaffEmailAddress> _staffEmailAddresses = new List<StaffEmailAddress>();
		private IList<StaffAddress> _staffAddresses = new List<StaffAddress>();
		private IList<Protocol> _protocols2 = new List<Protocol>();
		private IList<ReportPart> _reportParts2 = new List<ReportPart>();
		private IList<ReportPart> _reportParts3 = new List<ReportPart>();
		private IList<ReportPart> _reportParts4 = new List<ReportPart>();
		private IList<ReportPart> _reportParts5 = new List<ReportPart>();
		
		#endregion

        #region Constructors

        public Staff() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_id);
			sb.Append(_familyName);
			sb.Append(_givenName);
			sb.Append(_middleName);
			sb.Append(_prefix);
			sb.Append(_suffix);
			sb.Append(_degree);
			sb.Append(_title);
			sb.Append(_licenseNumber);
			sb.Append(_billingNumber);
			sb.Append(_userName);
			sb.Append(_deactivated);

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
		
		public virtual string Id
        {
            get { return _id; }
			set
			{
				OnIdChanging();
				_id = value;
				OnIdChanged();
			}
        }
		partial void OnIdChanging();
		partial void OnIdChanged();
		
		public virtual string FamilyName
        {
            get { return _familyName; }
			set
			{
				OnFamilyNameChanging();
				_familyName = value;
				OnFamilyNameChanged();
			}
        }
		partial void OnFamilyNameChanging();
		partial void OnFamilyNameChanged();
		
		public virtual string GivenName
        {
            get { return _givenName; }
			set
			{
				OnGivenNameChanging();
				_givenName = value;
				OnGivenNameChanged();
			}
        }
		partial void OnGivenNameChanging();
		partial void OnGivenNameChanged();
		
		public virtual string MiddleName
        {
            get { return _middleName; }
			set
			{
				OnMiddleNameChanging();
				_middleName = value;
				OnMiddleNameChanged();
			}
        }
		partial void OnMiddleNameChanging();
		partial void OnMiddleNameChanged();
		
		public virtual string Prefix
        {
            get { return _prefix; }
			set
			{
				OnPrefixChanging();
				_prefix = value;
				OnPrefixChanged();
			}
        }
		partial void OnPrefixChanging();
		partial void OnPrefixChanged();
		
		public virtual string Suffix
        {
            get { return _suffix; }
			set
			{
				OnSuffixChanging();
				_suffix = value;
				OnSuffixChanged();
			}
        }
		partial void OnSuffixChanging();
		partial void OnSuffixChanged();
		
		public virtual string Degree
        {
            get { return _degree; }
			set
			{
				OnDegreeChanging();
				_degree = value;
				OnDegreeChanged();
			}
        }
		partial void OnDegreeChanging();
		partial void OnDegreeChanged();
		
		public virtual string Title
        {
            get { return _title; }
			set
			{
				OnTitleChanging();
				_title = value;
				OnTitleChanged();
			}
        }
		partial void OnTitleChanging();
		partial void OnTitleChanged();
		
		public virtual string LicenseNumber
        {
            get { return _licenseNumber; }
			set
			{
				OnLicenseNumberChanging();
				_licenseNumber = value;
				OnLicenseNumberChanged();
			}
        }
		partial void OnLicenseNumberChanging();
		partial void OnLicenseNumberChanged();
		
		public virtual string BillingNumber
        {
            get { return _billingNumber; }
			set
			{
				OnBillingNumberChanging();
				_billingNumber = value;
				OnBillingNumberChanged();
			}
        }
		partial void OnBillingNumberChanging();
		partial void OnBillingNumberChanged();
		
		public virtual string UserName
        {
            get { return _userName; }
			set
			{
				OnUserNameChanging();
				_userName = value;
				OnUserNameChanged();
			}
        }
		partial void OnUserNameChanging();
		partial void OnUserNameChanged();
		
		public virtual bool Deactivated
        {
            get { return _deactivated; }
			set
			{
				OnDeactivatedChanging();
				_deactivated = value;
				OnDeactivatedChanged();
			}
        }
		partial void OnDeactivatedChanging();
		partial void OnDeactivatedChanged();
		
		public virtual SexEnum SexEnum
        {
            get { return _sexEnum; }
			set
			{
				OnSexEnumChanging();
				_sexEnum = value;
				OnSexEnumChanged();
			}
        }
		partial void OnSexEnumChanging();
		partial void OnSexEnumChanged();
		
		public virtual StaffTypeEnum StaffTypeEnum
        {
            get { return _staffTypeEnum; }
			set
			{
				OnStaffTypeEnumChanging();
				_staffTypeEnum = value;
				OnStaffTypeEnumChanged();
			}
        }
		partial void OnStaffTypeEnumChanging();
		partial void OnStaffTypeEnumChanged();
		
		public virtual IList<NotePosting> NotePostings1
        {
            get { return _notePostings1; }
            set
			{
				OnNotePostings1Changing();
				_notePostings1 = value;
				OnNotePostings1Changed();
			}
        }
		partial void OnNotePostings1Changing();
		partial void OnNotePostings1Changed();
		
		public virtual IList<OrderAttachment> OrderAttachments
        {
            get { return _orderAttachments; }
            set
			{
				OnOrderAttachmentsChanging();
				_orderAttachments = value;
				OnOrderAttachmentsChanged();
			}
        }
		partial void OnOrderAttachmentsChanging();
		partial void OnOrderAttachmentsChanged();
		
		public virtual IList<PatientAttachment> PatientAttachments
        {
            get { return _patientAttachments; }
            set
			{
				OnPatientAttachmentsChanging();
				_patientAttachments = value;
				OnPatientAttachmentsChanged();
			}
        }
		partial void OnPatientAttachmentsChanging();
		partial void OnPatientAttachmentsChanged();
		
		public virtual IList<Note> Notes
        {
            get { return _notes; }
            set
			{
				OnNotesChanging();
				_notes = value;
				OnNotesChanged();
			}
        }
		partial void OnNotesChanging();
		partial void OnNotesChanged();
		
		public virtual IList<PatientNote> PatientNotes
        {
            get { return _patientNotes; }
            set
			{
				OnPatientNotesChanging();
				_patientNotes = value;
				OnPatientNotesChanged();
			}
        }
		partial void OnPatientNotesChanging();
		partial void OnPatientNotesChanged();
		
		public virtual IList<Protocol> Protocols1
        {
            get { return _protocols1; }
            set
			{
				OnProtocols1Changing();
				_protocols1 = value;
				OnProtocols1Changed();
			}
        }
		partial void OnProtocols1Changing();
		partial void OnProtocols1Changed();
		
		public virtual IList<Order> Orders1
        {
            get { return _orders1; }
            set
			{
				OnOrders1Changing();
				_orders1 = value;
				OnOrders1Changed();
			}
        }
		partial void OnOrders1Changing();
		partial void OnOrders1Changed();
		
		public virtual IList<Order> Orders2
        {
            get { return _orders2; }
            set
			{
				OnOrders2Changing();
				_orders2 = value;
				OnOrders2Changed();
			}
        }
		partial void OnOrders2Changing();
		partial void OnOrders2Changed();
		
		public virtual IList<ReportPart> ReportParts1
        {
            get { return _reportParts1; }
            set
			{
				OnReportParts1Changing();
				_reportParts1 = value;
				OnReportParts1Changed();
			}
        }
		partial void OnReportParts1Changing();
		partial void OnReportParts1Changed();
		
		public virtual IList<Worklist> Worklists
        {
            get { return _worklists; }
            set
			{
				OnWorklistsChanging();
				_worklists = value;
				OnWorklistsChanged();
			}
        }
		partial void OnWorklistsChanging();
		partial void OnWorklistsChanged();
		
		public virtual IList<ProcedureStep> ProcedureSteps1
        {
            get { return _procedureSteps1; }
            set
			{
				OnProcedureSteps1Changing();
				_procedureSteps1 = value;
				OnProcedureSteps1Changed();
			}
        }
		partial void OnProcedureSteps1Changing();
		partial void OnProcedureSteps1Changed();
		
		public virtual IList<PerformedProcedureStep> PerformedProcedureSteps
        {
            get { return _performedProcedureSteps; }
            set
			{
				OnPerformedProcedureStepsChanging();
				_performedProcedureSteps = value;
				OnPerformedProcedureStepsChanged();
			}
        }
		partial void OnPerformedProcedureStepsChanging();
		partial void OnPerformedProcedureStepsChanged();
		
		public virtual IList<NotePosting> NotePostings2
        {
            get { return _notePostings2; }
            set
			{
				OnNotePostings2Changing();
				_notePostings2 = value;
				OnNotePostings2Changed();
			}
        }
		partial void OnNotePostings2Changing();
		partial void OnNotePostings2Changed();
		
		public virtual IList<ProcedureStep> ProcedureSteps2
        {
            get { return _procedureSteps2; }
            set
			{
				OnProcedureSteps2Changing();
				_procedureSteps2 = value;
				OnProcedureSteps2Changed();
			}
        }
		partial void OnProcedureSteps2Changing();
		partial void OnProcedureSteps2Changed();
		
		public virtual IList<CannedText> CannedTexts
        {
            get { return _cannedTexts; }
            set
			{
				OnCannedTextsChanging();
				_cannedTexts = value;
				OnCannedTextsChanged();
			}
        }
		partial void OnCannedTextsChanging();
		partial void OnCannedTextsChanged();
		
		public virtual IList<StaffTelephoneNumber> StaffTelephoneNumbers
        {
            get { return _staffTelephoneNumbers; }
            set
			{
				OnStaffTelephoneNumbersChanging();
				_staffTelephoneNumbers = value;
				OnStaffTelephoneNumbersChanged();
			}
        }
		partial void OnStaffTelephoneNumbersChanging();
		partial void OnStaffTelephoneNumbersChanged();
		
		public virtual IList<StaffEmailAddress> StaffEmailAddresses
        {
            get { return _staffEmailAddresses; }
            set
			{
				OnStaffEmailAddressesChanging();
				_staffEmailAddresses = value;
				OnStaffEmailAddressesChanged();
			}
        }
		partial void OnStaffEmailAddressesChanging();
		partial void OnStaffEmailAddressesChanged();
		
		public virtual IList<StaffAddress> StaffAddresses
        {
            get { return _staffAddresses; }
            set
			{
				OnStaffAddressesChanging();
				_staffAddresses = value;
				OnStaffAddressesChanged();
			}
        }
		partial void OnStaffAddressesChanging();
		partial void OnStaffAddressesChanged();
		
		public virtual IList<Protocol> Protocols2
        {
            get { return _protocols2; }
            set
			{
				OnProtocols2Changing();
				_protocols2 = value;
				OnProtocols2Changed();
			}
        }
		partial void OnProtocols2Changing();
		partial void OnProtocols2Changed();
		
		public virtual IList<ReportPart> ReportParts2
        {
            get { return _reportParts2; }
            set
			{
				OnReportParts2Changing();
				_reportParts2 = value;
				OnReportParts2Changed();
			}
        }
		partial void OnReportParts2Changing();
		partial void OnReportParts2Changed();
		
		public virtual IList<ReportPart> ReportParts3
        {
            get { return _reportParts3; }
            set
			{
				OnReportParts3Changing();
				_reportParts3 = value;
				OnReportParts3Changed();
			}
        }
		partial void OnReportParts3Changing();
		partial void OnReportParts3Changed();
		
		public virtual IList<ReportPart> ReportParts4
        {
            get { return _reportParts4; }
            set
			{
				OnReportParts4Changing();
				_reportParts4 = value;
				OnReportParts4Changed();
			}
        }
		partial void OnReportParts4Changing();
		partial void OnReportParts4Changed();
		
		public virtual IList<ReportPart> ReportParts5
        {
            get { return _reportParts5; }
            set
			{
				OnReportParts5Changing();
				_reportParts5 = value;
				OnReportParts5Changed();
			}
        }
		partial void OnReportParts5Changing();
		partial void OnReportParts5Changed();
		
        #endregion
    }
}
