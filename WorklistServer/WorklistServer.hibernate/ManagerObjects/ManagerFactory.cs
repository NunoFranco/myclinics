using System;
using System.Collections.Generic;
using System.Text;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public interface IManagerFactory
    {
		// Get Methods
		IAccessionSequenceManager GetAccessionSequenceManager();
		IAccessionSequenceManager GetAccessionSequenceManager(INHibernateSession session);
		IActivityStatusEnumManager GetActivityStatusEnumManager();
		IActivityStatusEnumManager GetActivityStatusEnumManager(INHibernateSession session);
		IAddressTypeEnumManager GetAddressTypeEnumManager();
		IAddressTypeEnumManager GetAddressTypeEnumManager(INHibernateSession session);
		IAdmissionTypeEnumManager GetAdmissionTypeEnumManager();
		IAdmissionTypeEnumManager GetAdmissionTypeEnumManager(INHibernateSession session);
		IAmbulatoryStatusEnumManager GetAmbulatoryStatusEnumManager();
		IAmbulatoryStatusEnumManager GetAmbulatoryStatusEnumManager(INHibernateSession session);
		IAttachedDocumentManager GetAttachedDocumentManager();
		IAttachedDocumentManager GetAttachedDocumentManager(INHibernateSession session);
		IAuditLogManager GetAuditLogManager();
		IAuditLogManager GetAuditLogManager(INHibernateSession session);
		IAuthorityGroupManager GetAuthorityGroupManager();
		IAuthorityGroupManager GetAuthorityGroupManager(INHibernateSession session);
		IAuthorityTokenManager GetAuthorityTokenManager();
		IAuthorityTokenManager GetAuthorityTokenManager(INHibernateSession session);
		ICannedTextManager GetCannedTextManager();
		ICannedTextManager GetCannedTextManager(INHibernateSession session);
		IConfigurationDocumentManager GetConfigurationDocumentManager();
		IConfigurationDocumentManager GetConfigurationDocumentManager(INHibernateSession session);
		IConfigurationDocumentBodyManager GetConfigurationDocumentBodyManager();
		IConfigurationDocumentBodyManager GetConfigurationDocumentBodyManager(INHibernateSession session);
		IConfigurationSettingsGroupManager GetConfigurationSettingsGroupManager();
		IConfigurationSettingsGroupManager GetConfigurationSettingsGroupManager(INHibernateSession session);
		IConfigurationSettingsPropertyManager GetConfigurationSettingsPropertyManager();
		IConfigurationSettingsPropertyManager GetConfigurationSettingsPropertyManager(INHibernateSession session);
		IContactPersonRelationshipEnumManager GetContactPersonRelationshipEnumManager();
		IContactPersonRelationshipEnumManager GetContactPersonRelationshipEnumManager(INHibernateSession session);
		IContactPersonTypeEnumManager GetContactPersonTypeEnumManager();
		IContactPersonTypeEnumManager GetContactPersonTypeEnumManager(INHibernateSession session);
		IDiagnosticServiceManager GetDiagnosticServiceManager();
		IDiagnosticServiceManager GetDiagnosticServiceManager(INHibernateSession session);
		IDicomSeriesManager GetDicomSeriesManager();
		IDicomSeriesManager GetDicomSeriesManager(INHibernateSession session);
		IExceptionLogManager GetExceptionLogManager();
		IExceptionLogManager GetExceptionLogManager(INHibernateSession session);
		IExternalPractitionerManager GetExternalPractitionerManager();
		IExternalPractitionerManager GetExternalPractitionerManager(INHibernateSession session);
		IExternalPractitionerContactPointManager GetExternalPractitionerContactPointManager();
		IExternalPractitionerContactPointManager GetExternalPractitionerContactPointManager(INHibernateSession session);
		IExternalPractitionerContactPointAddressManager GetExternalPractitionerContactPointAddressManager();
		IExternalPractitionerContactPointAddressManager GetExternalPractitionerContactPointAddressManager(INHibernateSession session);
		IExternalPractitionerContactPointEmailAddressManager GetExternalPractitionerContactPointEmailAddressManager();
		IExternalPractitionerContactPointEmailAddressManager GetExternalPractitionerContactPointEmailAddressManager(INHibernateSession session);
		IExternalPractitionerContactPointTelephoneNumberManager GetExternalPractitionerContactPointTelephoneNumberManager();
		IExternalPractitionerContactPointTelephoneNumberManager GetExternalPractitionerContactPointTelephoneNumberManager(INHibernateSession session);
		IExternalPractitionerExtendedPropertyManager GetExternalPractitionerExtendedPropertyManager();
		IExternalPractitionerExtendedPropertyManager GetExternalPractitionerExtendedPropertyManager(INHibernateSession session);
		IFacilityManager GetFacilityManager();
		IFacilityManager GetFacilityManager(INHibernateSession session);
		IImageAvailabilityEnumManager GetImageAvailabilityEnumManager();
		IImageAvailabilityEnumManager GetImageAvailabilityEnumManager(INHibernateSession session);
		IInformationAuthorityEnumManager GetInformationAuthorityEnumManager();
		IInformationAuthorityEnumManager GetInformationAuthorityEnumManager(INHibernateSession session);
		IInsuranceAuthorityEnumManager GetInsuranceAuthorityEnumManager();
		IInsuranceAuthorityEnumManager GetInsuranceAuthorityEnumManager(INHibernateSession session);
		ILateralityEnumManager GetLateralityEnumManager();
		ILateralityEnumManager GetLateralityEnumManager(INHibernateSession session);
		ILocationManager GetLocationManager();
		ILocationManager GetLocationManager(INHibernateSession session);
		IModalityManager GetModalityManager();
		IModalityManager GetModalityManager(INHibernateSession session);
		INoteManager GetNoteManager();
		INoteManager GetNoteManager(INHibernateSession session);
		INotePostingManager GetNotePostingManager();
		INotePostingManager GetNotePostingManager(INHibernateSession session);
		INoteSeverityEnumManager GetNoteSeverityEnumManager();
		INoteSeverityEnumManager GetNoteSeverityEnumManager(INHibernateSession session);
		IOrderManager GetOrderManager();
		IOrderManager GetOrderManager(INHibernateSession session);
		IOrderAttachmentManager GetOrderAttachmentManager();
		IOrderAttachmentManager GetOrderAttachmentManager(INHibernateSession session);
		IOrderAttachmentCategoryEnumManager GetOrderAttachmentCategoryEnumManager();
		IOrderAttachmentCategoryEnumManager GetOrderAttachmentCategoryEnumManager(INHibernateSession session);
		IOrderCancelReasonEnumManager GetOrderCancelReasonEnumManager();
		IOrderCancelReasonEnumManager GetOrderCancelReasonEnumManager(INHibernateSession session);
		IOrderExtendedPropertyManager GetOrderExtendedPropertyManager();
		IOrderExtendedPropertyManager GetOrderExtendedPropertyManager(INHibernateSession session);
		IOrderPriorityEnumManager GetOrderPriorityEnumManager();
		IOrderPriorityEnumManager GetOrderPriorityEnumManager(INHibernateSession session);
		IOrderResultRecipientManager GetOrderResultRecipientManager();
		IOrderResultRecipientManager GetOrderResultRecipientManager(INHibernateSession session);
		IOrderStatusEnumManager GetOrderStatusEnumManager();
		IOrderStatusEnumManager GetOrderStatusEnumManager(INHibernateSession session);
		IPatientManager GetPatientManager();
		IPatientManager GetPatientManager(INHibernateSession session);
		IPatientAttachmentManager GetPatientAttachmentManager();
		IPatientAttachmentManager GetPatientAttachmentManager(INHibernateSession session);
		IPatientAttachmentCategoryEnumManager GetPatientAttachmentCategoryEnumManager();
		IPatientAttachmentCategoryEnumManager GetPatientAttachmentCategoryEnumManager(INHibernateSession session);
		IPatientClassEnumManager GetPatientClassEnumManager();
		IPatientClassEnumManager GetPatientClassEnumManager(INHibernateSession session);
		IPatientNoteManager GetPatientNoteManager();
		IPatientNoteManager GetPatientNoteManager(INHibernateSession session);
		IPatientNoteCategoryManager GetPatientNoteCategoryManager();
		IPatientNoteCategoryManager GetPatientNoteCategoryManager(INHibernateSession session);
		IPatientProfileManager GetPatientProfileManager();
		IPatientProfileManager GetPatientProfileManager(INHibernateSession session);
		IPatientProfileAddressManager GetPatientProfileAddressManager();
		IPatientProfileAddressManager GetPatientProfileAddressManager(INHibernateSession session);
		IPatientProfileContactPersonManager GetPatientProfileContactPersonManager();
		IPatientProfileContactPersonManager GetPatientProfileContactPersonManager(INHibernateSession session);
		IPatientProfileEmailAddressManager GetPatientProfileEmailAddressManager();
		IPatientProfileEmailAddressManager GetPatientProfileEmailAddressManager(INHibernateSession session);
		IPatientProfileExpiredMrnManager GetPatientProfileExpiredMrnManager();
		IPatientProfileExpiredMrnManager GetPatientProfileExpiredMrnManager(INHibernateSession session);
		IPatientProfileTelephoneNumberManager GetPatientProfileTelephoneNumberManager();
		IPatientProfileTelephoneNumberManager GetPatientProfileTelephoneNumberManager(INHibernateSession session);
		IPatientTypeEnumManager GetPatientTypeEnumManager();
		IPatientTypeEnumManager GetPatientTypeEnumManager(INHibernateSession session);
		IPerformedProcedureStepManager GetPerformedProcedureStepManager();
		IPerformedProcedureStepManager GetPerformedProcedureStepManager(INHibernateSession session);
		IPerformedProcedureStepExtendedPropertyManager GetPerformedProcedureStepExtendedPropertyManager();
		IPerformedProcedureStepExtendedPropertyManager GetPerformedProcedureStepExtendedPropertyManager(INHibernateSession session);
		IPerformedStepStatusEnumManager GetPerformedStepStatusEnumManager();
		IPerformedStepStatusEnumManager GetPerformedStepStatusEnumManager(INHibernateSession session);
		IProcedureManager GetProcedureManager();
		IProcedureManager GetProcedureManager(INHibernateSession session);
		IProcedureCheckInManager GetProcedureCheckInManager();
		IProcedureCheckInManager GetProcedureCheckInManager(INHibernateSession session);
		IProcedureStatusEnumManager GetProcedureStatusEnumManager();
		IProcedureStatusEnumManager GetProcedureStatusEnumManager(INHibernateSession session);
		IProcedureStepManager GetProcedureStepManager();
		IProcedureStepManager GetProcedureStepManager(INHibernateSession session);
		IProcedureTypeManager GetProcedureTypeManager();
		IProcedureTypeManager GetProcedureTypeManager(INHibernateSession session);
		IProcedureTypeGroupManager GetProcedureTypeGroupManager();
		IProcedureTypeGroupManager GetProcedureTypeGroupManager(INHibernateSession session);
		IProtocolManager GetProtocolManager();
		IProtocolManager GetProtocolManager(INHibernateSession session);
		IProtocolCodeManager GetProtocolCodeManager();
		IProtocolCodeManager GetProtocolCodeManager(INHibernateSession session);
		IProtocolGroupManager GetProtocolGroupManager();
		IProtocolGroupManager GetProtocolGroupManager(INHibernateSession session);
		IProtocolRejectReasonEnumManager GetProtocolRejectReasonEnumManager();
		IProtocolRejectReasonEnumManager GetProtocolRejectReasonEnumManager(INHibernateSession session);
		IProtocolStatusEnumManager GetProtocolStatusEnumManager();
		IProtocolStatusEnumManager GetProtocolStatusEnumManager(INHibernateSession session);
		IProtocolUrgencyEnumManager GetProtocolUrgencyEnumManager();
		IProtocolUrgencyEnumManager GetProtocolUrgencyEnumManager(INHibernateSession session);
		IReligionEnumManager GetReligionEnumManager();
		IReligionEnumManager GetReligionEnumManager(INHibernateSession session);
		IReportManager GetReportManager();
		IReportManager GetReportManager(INHibernateSession session);
		IReportPartManager GetReportPartManager();
		IReportPartManager GetReportPartManager(INHibernateSession session);
		IReportPartExtendedPropertyManager GetReportPartExtendedPropertyManager();
		IReportPartExtendedPropertyManager GetReportPartExtendedPropertyManager(INHibernateSession session);
		IReportPartStatusEnumManager GetReportPartStatusEnumManager();
		IReportPartStatusEnumManager GetReportPartStatusEnumManager(INHibernateSession session);
		IReportStatusEnumManager GetReportStatusEnumManager();
		IReportStatusEnumManager GetReportStatusEnumManager(INHibernateSession session);
		IResultCommunicationModeEnumManager GetResultCommunicationModeEnumManager();
		IResultCommunicationModeEnumManager GetResultCommunicationModeEnumManager(INHibernateSession session);
		ISexEnumManager GetSexEnumManager();
		ISexEnumManager GetSexEnumManager(INHibernateSession session);
		ISpokenLanguageEnumManager GetSpokenLanguageEnumManager();
		ISpokenLanguageEnumManager GetSpokenLanguageEnumManager(INHibernateSession session);
		IStaffManager GetStaffManager();
		IStaffManager GetStaffManager(INHibernateSession session);
		IStaffAddressManager GetStaffAddressManager();
		IStaffAddressManager GetStaffAddressManager(INHibernateSession session);
		IStaffEmailAddressManager GetStaffEmailAddressManager();
		IStaffEmailAddressManager GetStaffEmailAddressManager(INHibernateSession session);
		IStaffExtendedPropertyManager GetStaffExtendedPropertyManager();
		IStaffExtendedPropertyManager GetStaffExtendedPropertyManager(INHibernateSession session);
		IStaffGroupManager GetStaffGroupManager();
		IStaffGroupManager GetStaffGroupManager(INHibernateSession session);
		IStaffTelephoneNumberManager GetStaffTelephoneNumberManager();
		IStaffTelephoneNumberManager GetStaffTelephoneNumberManager(INHibernateSession session);
		IStaffTypeEnumManager GetStaffTypeEnumManager();
		IStaffTypeEnumManager GetStaffTypeEnumManager(INHibernateSession session);
		ITelephoneEquipmentEnumManager GetTelephoneEquipmentEnumManager();
		ITelephoneEquipmentEnumManager GetTelephoneEquipmentEnumManager(INHibernateSession session);
		ITelephoneUseEnumManager GetTelephoneUseEnumManager();
		ITelephoneUseEnumManager GetTelephoneUseEnumManager(INHibernateSession session);
		ITestManager GetTestManager();
		ITestManager GetTestManager(INHibernateSession session);
		ITranscriptionRejectReasonEnumManager GetTranscriptionRejectReasonEnumManager();
		ITranscriptionRejectReasonEnumManager GetTranscriptionRejectReasonEnumManager(INHibernateSession session);
		IUserManager GetUserManager();
		IUserManager GetUserManager(INHibernateSession session);
		IUserSessionManager GetUserSessionManager();
		IUserSessionManager GetUserSessionManager(INHibernateSession session);
		IVisitManager GetVisitManager();
		IVisitManager GetVisitManager(INHibernateSession session);
		IVisitExtendedPropertyManager GetVisitExtendedPropertyManager();
		IVisitExtendedPropertyManager GetVisitExtendedPropertyManager(INHibernateSession session);
		IVisitLocationManager GetVisitLocationManager();
		IVisitLocationManager GetVisitLocationManager(INHibernateSession session);
		IVisitLocationRoleEnumManager GetVisitLocationRoleEnumManager();
		IVisitLocationRoleEnumManager GetVisitLocationRoleEnumManager(INHibernateSession session);
		IVisitPractitionerManager GetVisitPractitionerManager();
		IVisitPractitionerManager GetVisitPractitionerManager(INHibernateSession session);
		IVisitPractitionerRoleEnumManager GetVisitPractitionerRoleEnumManager();
		IVisitPractitionerRoleEnumManager GetVisitPractitionerRoleEnumManager(INHibernateSession session);
		IVisitStatusEnumManager GetVisitStatusEnumManager();
		IVisitStatusEnumManager GetVisitStatusEnumManager(INHibernateSession session);
		IWorklistManager GetWorklistManager();
		IWorklistManager GetWorklistManager(INHibernateSession session);
		IWorkQueueExtendedPropertyManager GetWorkQueueExtendedPropertyManager();
		IWorkQueueExtendedPropertyManager GetWorkQueueExtendedPropertyManager(INHibernateSession session);
		IWorkQueueItemManager GetWorkQueueItemManager();
		IWorkQueueItemManager GetWorkQueueItemManager(INHibernateSession session);
		IWorkQueueStatusEnumManager GetWorkQueueStatusEnumManager();
		IWorkQueueStatusEnumManager GetWorkQueueStatusEnumManager(INHibernateSession session);
    }

    public class ManagerFactory : IManagerFactory
    {
        #region Constructors

        public ManagerFactory()
        {
        }

        #endregion

        #region Get Methods

		public IAccessionSequenceManager GetAccessionSequenceManager()
        {
            return new AccessionSequenceManager();
        }
		public IAccessionSequenceManager GetAccessionSequenceManager(INHibernateSession session)
        {
            return new AccessionSequenceManager(session);
        }
		public IActivityStatusEnumManager GetActivityStatusEnumManager()
        {
            return new ActivityStatusEnumManager();
        }
		public IActivityStatusEnumManager GetActivityStatusEnumManager(INHibernateSession session)
        {
            return new ActivityStatusEnumManager(session);
        }
		public IAddressTypeEnumManager GetAddressTypeEnumManager()
        {
            return new AddressTypeEnumManager();
        }
		public IAddressTypeEnumManager GetAddressTypeEnumManager(INHibernateSession session)
        {
            return new AddressTypeEnumManager(session);
        }
		public IAdmissionTypeEnumManager GetAdmissionTypeEnumManager()
        {
            return new AdmissionTypeEnumManager();
        }
		public IAdmissionTypeEnumManager GetAdmissionTypeEnumManager(INHibernateSession session)
        {
            return new AdmissionTypeEnumManager(session);
        }
		public IAmbulatoryStatusEnumManager GetAmbulatoryStatusEnumManager()
        {
            return new AmbulatoryStatusEnumManager();
        }
		public IAmbulatoryStatusEnumManager GetAmbulatoryStatusEnumManager(INHibernateSession session)
        {
            return new AmbulatoryStatusEnumManager(session);
        }
		public IAttachedDocumentManager GetAttachedDocumentManager()
        {
            return new AttachedDocumentManager();
        }
		public IAttachedDocumentManager GetAttachedDocumentManager(INHibernateSession session)
        {
            return new AttachedDocumentManager(session);
        }
		public IAuditLogManager GetAuditLogManager()
        {
            return new AuditLogManager();
        }
		public IAuditLogManager GetAuditLogManager(INHibernateSession session)
        {
            return new AuditLogManager(session);
        }
		public IAuthorityGroupManager GetAuthorityGroupManager()
        {
            return new AuthorityGroupManager();
        }
		public IAuthorityGroupManager GetAuthorityGroupManager(INHibernateSession session)
        {
            return new AuthorityGroupManager(session);
        }
		public IAuthorityTokenManager GetAuthorityTokenManager()
        {
            return new AuthorityTokenManager();
        }
		public IAuthorityTokenManager GetAuthorityTokenManager(INHibernateSession session)
        {
            return new AuthorityTokenManager(session);
        }
		public ICannedTextManager GetCannedTextManager()
        {
            return new CannedTextManager();
        }
		public ICannedTextManager GetCannedTextManager(INHibernateSession session)
        {
            return new CannedTextManager(session);
        }
		public IConfigurationDocumentManager GetConfigurationDocumentManager()
        {
            return new ConfigurationDocumentManager();
        }
		public IConfigurationDocumentManager GetConfigurationDocumentManager(INHibernateSession session)
        {
            return new ConfigurationDocumentManager(session);
        }
		public IConfigurationDocumentBodyManager GetConfigurationDocumentBodyManager()
        {
            return new ConfigurationDocumentBodyManager();
        }
		public IConfigurationDocumentBodyManager GetConfigurationDocumentBodyManager(INHibernateSession session)
        {
            return new ConfigurationDocumentBodyManager(session);
        }
		public IConfigurationSettingsGroupManager GetConfigurationSettingsGroupManager()
        {
            return new ConfigurationSettingsGroupManager();
        }
		public IConfigurationSettingsGroupManager GetConfigurationSettingsGroupManager(INHibernateSession session)
        {
            return new ConfigurationSettingsGroupManager(session);
        }
		public IConfigurationSettingsPropertyManager GetConfigurationSettingsPropertyManager()
        {
            return new ConfigurationSettingsPropertyManager();
        }
		public IConfigurationSettingsPropertyManager GetConfigurationSettingsPropertyManager(INHibernateSession session)
        {
            return new ConfigurationSettingsPropertyManager(session);
        }
		public IContactPersonRelationshipEnumManager GetContactPersonRelationshipEnumManager()
        {
            return new ContactPersonRelationshipEnumManager();
        }
		public IContactPersonRelationshipEnumManager GetContactPersonRelationshipEnumManager(INHibernateSession session)
        {
            return new ContactPersonRelationshipEnumManager(session);
        }
		public IContactPersonTypeEnumManager GetContactPersonTypeEnumManager()
        {
            return new ContactPersonTypeEnumManager();
        }
		public IContactPersonTypeEnumManager GetContactPersonTypeEnumManager(INHibernateSession session)
        {
            return new ContactPersonTypeEnumManager(session);
        }
		public IDiagnosticServiceManager GetDiagnosticServiceManager()
        {
            return new DiagnosticServiceManager();
        }
		public IDiagnosticServiceManager GetDiagnosticServiceManager(INHibernateSession session)
        {
            return new DiagnosticServiceManager(session);
        }
		public IDicomSeriesManager GetDicomSeriesManager()
        {
            return new DicomSeriesManager();
        }
		public IDicomSeriesManager GetDicomSeriesManager(INHibernateSession session)
        {
            return new DicomSeriesManager(session);
        }
		public IExceptionLogManager GetExceptionLogManager()
        {
            return new ExceptionLogManager();
        }
		public IExceptionLogManager GetExceptionLogManager(INHibernateSession session)
        {
            return new ExceptionLogManager(session);
        }
		public IExternalPractitionerManager GetExternalPractitionerManager()
        {
            return new ExternalPractitionerManager();
        }
		public IExternalPractitionerManager GetExternalPractitionerManager(INHibernateSession session)
        {
            return new ExternalPractitionerManager(session);
        }
		public IExternalPractitionerContactPointManager GetExternalPractitionerContactPointManager()
        {
            return new ExternalPractitionerContactPointManager();
        }
		public IExternalPractitionerContactPointManager GetExternalPractitionerContactPointManager(INHibernateSession session)
        {
            return new ExternalPractitionerContactPointManager(session);
        }
		public IExternalPractitionerContactPointAddressManager GetExternalPractitionerContactPointAddressManager()
        {
            return new ExternalPractitionerContactPointAddressManager();
        }
		public IExternalPractitionerContactPointAddressManager GetExternalPractitionerContactPointAddressManager(INHibernateSession session)
        {
            return new ExternalPractitionerContactPointAddressManager(session);
        }
		public IExternalPractitionerContactPointEmailAddressManager GetExternalPractitionerContactPointEmailAddressManager()
        {
            return new ExternalPractitionerContactPointEmailAddressManager();
        }
		public IExternalPractitionerContactPointEmailAddressManager GetExternalPractitionerContactPointEmailAddressManager(INHibernateSession session)
        {
            return new ExternalPractitionerContactPointEmailAddressManager(session);
        }
		public IExternalPractitionerContactPointTelephoneNumberManager GetExternalPractitionerContactPointTelephoneNumberManager()
        {
            return new ExternalPractitionerContactPointTelephoneNumberManager();
        }
		public IExternalPractitionerContactPointTelephoneNumberManager GetExternalPractitionerContactPointTelephoneNumberManager(INHibernateSession session)
        {
            return new ExternalPractitionerContactPointTelephoneNumberManager(session);
        }
		public IExternalPractitionerExtendedPropertyManager GetExternalPractitionerExtendedPropertyManager()
        {
            return new ExternalPractitionerExtendedPropertyManager();
        }
		public IExternalPractitionerExtendedPropertyManager GetExternalPractitionerExtendedPropertyManager(INHibernateSession session)
        {
            return new ExternalPractitionerExtendedPropertyManager(session);
        }
		public IFacilityManager GetFacilityManager()
        {
            return new FacilityManager();
        }
		public IFacilityManager GetFacilityManager(INHibernateSession session)
        {
            return new FacilityManager(session);
        }
		public IImageAvailabilityEnumManager GetImageAvailabilityEnumManager()
        {
            return new ImageAvailabilityEnumManager();
        }
		public IImageAvailabilityEnumManager GetImageAvailabilityEnumManager(INHibernateSession session)
        {
            return new ImageAvailabilityEnumManager(session);
        }
		public IInformationAuthorityEnumManager GetInformationAuthorityEnumManager()
        {
            return new InformationAuthorityEnumManager();
        }
		public IInformationAuthorityEnumManager GetInformationAuthorityEnumManager(INHibernateSession session)
        {
            return new InformationAuthorityEnumManager(session);
        }
		public IInsuranceAuthorityEnumManager GetInsuranceAuthorityEnumManager()
        {
            return new InsuranceAuthorityEnumManager();
        }
		public IInsuranceAuthorityEnumManager GetInsuranceAuthorityEnumManager(INHibernateSession session)
        {
            return new InsuranceAuthorityEnumManager(session);
        }
		public ILateralityEnumManager GetLateralityEnumManager()
        {
            return new LateralityEnumManager();
        }
		public ILateralityEnumManager GetLateralityEnumManager(INHibernateSession session)
        {
            return new LateralityEnumManager(session);
        }
		public ILocationManager GetLocationManager()
        {
            return new LocationManager();
        }
		public ILocationManager GetLocationManager(INHibernateSession session)
        {
            return new LocationManager(session);
        }
		public IModalityManager GetModalityManager()
        {
            return new ModalityManager();
        }
		public IModalityManager GetModalityManager(INHibernateSession session)
        {
            return new ModalityManager(session);
        }
		public INoteManager GetNoteManager()
        {
            return new NoteManager();
        }
		public INoteManager GetNoteManager(INHibernateSession session)
        {
            return new NoteManager(session);
        }
		public INotePostingManager GetNotePostingManager()
        {
            return new NotePostingManager();
        }
		public INotePostingManager GetNotePostingManager(INHibernateSession session)
        {
            return new NotePostingManager(session);
        }
		public INoteSeverityEnumManager GetNoteSeverityEnumManager()
        {
            return new NoteSeverityEnumManager();
        }
		public INoteSeverityEnumManager GetNoteSeverityEnumManager(INHibernateSession session)
        {
            return new NoteSeverityEnumManager(session);
        }
		public IOrderManager GetOrderManager()
        {
            return new OrderManager();
        }
		public IOrderManager GetOrderManager(INHibernateSession session)
        {
            return new OrderManager(session);
        }
		public IOrderAttachmentManager GetOrderAttachmentManager()
        {
            return new OrderAttachmentManager();
        }
		public IOrderAttachmentManager GetOrderAttachmentManager(INHibernateSession session)
        {
            return new OrderAttachmentManager(session);
        }
		public IOrderAttachmentCategoryEnumManager GetOrderAttachmentCategoryEnumManager()
        {
            return new OrderAttachmentCategoryEnumManager();
        }
		public IOrderAttachmentCategoryEnumManager GetOrderAttachmentCategoryEnumManager(INHibernateSession session)
        {
            return new OrderAttachmentCategoryEnumManager(session);
        }
		public IOrderCancelReasonEnumManager GetOrderCancelReasonEnumManager()
        {
            return new OrderCancelReasonEnumManager();
        }
		public IOrderCancelReasonEnumManager GetOrderCancelReasonEnumManager(INHibernateSession session)
        {
            return new OrderCancelReasonEnumManager(session);
        }
		public IOrderExtendedPropertyManager GetOrderExtendedPropertyManager()
        {
            return new OrderExtendedPropertyManager();
        }
		public IOrderExtendedPropertyManager GetOrderExtendedPropertyManager(INHibernateSession session)
        {
            return new OrderExtendedPropertyManager(session);
        }
		public IOrderPriorityEnumManager GetOrderPriorityEnumManager()
        {
            return new OrderPriorityEnumManager();
        }
		public IOrderPriorityEnumManager GetOrderPriorityEnumManager(INHibernateSession session)
        {
            return new OrderPriorityEnumManager(session);
        }
		public IOrderResultRecipientManager GetOrderResultRecipientManager()
        {
            return new OrderResultRecipientManager();
        }
		public IOrderResultRecipientManager GetOrderResultRecipientManager(INHibernateSession session)
        {
            return new OrderResultRecipientManager(session);
        }
		public IOrderStatusEnumManager GetOrderStatusEnumManager()
        {
            return new OrderStatusEnumManager();
        }
		public IOrderStatusEnumManager GetOrderStatusEnumManager(INHibernateSession session)
        {
            return new OrderStatusEnumManager(session);
        }
		public IPatientManager GetPatientManager()
        {
            return new PatientManager();
        }
		public IPatientManager GetPatientManager(INHibernateSession session)
        {
            return new PatientManager(session);
        }
		public IPatientAttachmentManager GetPatientAttachmentManager()
        {
            return new PatientAttachmentManager();
        }
		public IPatientAttachmentManager GetPatientAttachmentManager(INHibernateSession session)
        {
            return new PatientAttachmentManager(session);
        }
		public IPatientAttachmentCategoryEnumManager GetPatientAttachmentCategoryEnumManager()
        {
            return new PatientAttachmentCategoryEnumManager();
        }
		public IPatientAttachmentCategoryEnumManager GetPatientAttachmentCategoryEnumManager(INHibernateSession session)
        {
            return new PatientAttachmentCategoryEnumManager(session);
        }
		public IPatientClassEnumManager GetPatientClassEnumManager()
        {
            return new PatientClassEnumManager();
        }
		public IPatientClassEnumManager GetPatientClassEnumManager(INHibernateSession session)
        {
            return new PatientClassEnumManager(session);
        }
		public IPatientNoteManager GetPatientNoteManager()
        {
            return new PatientNoteManager();
        }
		public IPatientNoteManager GetPatientNoteManager(INHibernateSession session)
        {
            return new PatientNoteManager(session);
        }
		public IPatientNoteCategoryManager GetPatientNoteCategoryManager()
        {
            return new PatientNoteCategoryManager();
        }
		public IPatientNoteCategoryManager GetPatientNoteCategoryManager(INHibernateSession session)
        {
            return new PatientNoteCategoryManager(session);
        }
		public IPatientProfileManager GetPatientProfileManager()
        {
            return new PatientProfileManager();
        }
		public IPatientProfileManager GetPatientProfileManager(INHibernateSession session)
        {
            return new PatientProfileManager(session);
        }
		public IPatientProfileAddressManager GetPatientProfileAddressManager()
        {
            return new PatientProfileAddressManager();
        }
		public IPatientProfileAddressManager GetPatientProfileAddressManager(INHibernateSession session)
        {
            return new PatientProfileAddressManager(session);
        }
		public IPatientProfileContactPersonManager GetPatientProfileContactPersonManager()
        {
            return new PatientProfileContactPersonManager();
        }
		public IPatientProfileContactPersonManager GetPatientProfileContactPersonManager(INHibernateSession session)
        {
            return new PatientProfileContactPersonManager(session);
        }
		public IPatientProfileEmailAddressManager GetPatientProfileEmailAddressManager()
        {
            return new PatientProfileEmailAddressManager();
        }
		public IPatientProfileEmailAddressManager GetPatientProfileEmailAddressManager(INHibernateSession session)
        {
            return new PatientProfileEmailAddressManager(session);
        }
		public IPatientProfileExpiredMrnManager GetPatientProfileExpiredMrnManager()
        {
            return new PatientProfileExpiredMrnManager();
        }
		public IPatientProfileExpiredMrnManager GetPatientProfileExpiredMrnManager(INHibernateSession session)
        {
            return new PatientProfileExpiredMrnManager(session);
        }
		public IPatientProfileTelephoneNumberManager GetPatientProfileTelephoneNumberManager()
        {
            return new PatientProfileTelephoneNumberManager();
        }
		public IPatientProfileTelephoneNumberManager GetPatientProfileTelephoneNumberManager(INHibernateSession session)
        {
            return new PatientProfileTelephoneNumberManager(session);
        }
		public IPatientTypeEnumManager GetPatientTypeEnumManager()
        {
            return new PatientTypeEnumManager();
        }
		public IPatientTypeEnumManager GetPatientTypeEnumManager(INHibernateSession session)
        {
            return new PatientTypeEnumManager(session);
        }
		public IPerformedProcedureStepManager GetPerformedProcedureStepManager()
        {
            return new PerformedProcedureStepManager();
        }
		public IPerformedProcedureStepManager GetPerformedProcedureStepManager(INHibernateSession session)
        {
            return new PerformedProcedureStepManager(session);
        }
		public IPerformedProcedureStepExtendedPropertyManager GetPerformedProcedureStepExtendedPropertyManager()
        {
            return new PerformedProcedureStepExtendedPropertyManager();
        }
		public IPerformedProcedureStepExtendedPropertyManager GetPerformedProcedureStepExtendedPropertyManager(INHibernateSession session)
        {
            return new PerformedProcedureStepExtendedPropertyManager(session);
        }
		public IPerformedStepStatusEnumManager GetPerformedStepStatusEnumManager()
        {
            return new PerformedStepStatusEnumManager();
        }
		public IPerformedStepStatusEnumManager GetPerformedStepStatusEnumManager(INHibernateSession session)
        {
            return new PerformedStepStatusEnumManager(session);
        }
		public IProcedureManager GetProcedureManager()
        {
            return new ProcedureManager();
        }
		public IProcedureManager GetProcedureManager(INHibernateSession session)
        {
            return new ProcedureManager(session);
        }
		public IProcedureCheckInManager GetProcedureCheckInManager()
        {
            return new ProcedureCheckInManager();
        }
		public IProcedureCheckInManager GetProcedureCheckInManager(INHibernateSession session)
        {
            return new ProcedureCheckInManager(session);
        }
		public IProcedureStatusEnumManager GetProcedureStatusEnumManager()
        {
            return new ProcedureStatusEnumManager();
        }
		public IProcedureStatusEnumManager GetProcedureStatusEnumManager(INHibernateSession session)
        {
            return new ProcedureStatusEnumManager(session);
        }
		public IProcedureStepManager GetProcedureStepManager()
        {
            return new ProcedureStepManager();
        }
		public IProcedureStepManager GetProcedureStepManager(INHibernateSession session)
        {
            return new ProcedureStepManager(session);
        }
		public IProcedureTypeManager GetProcedureTypeManager()
        {
            return new ProcedureTypeManager();
        }
		public IProcedureTypeManager GetProcedureTypeManager(INHibernateSession session)
        {
            return new ProcedureTypeManager(session);
        }
		public IProcedureTypeGroupManager GetProcedureTypeGroupManager()
        {
            return new ProcedureTypeGroupManager();
        }
		public IProcedureTypeGroupManager GetProcedureTypeGroupManager(INHibernateSession session)
        {
            return new ProcedureTypeGroupManager(session);
        }
		public IProtocolManager GetProtocolManager()
        {
            return new ProtocolManager();
        }
		public IProtocolManager GetProtocolManager(INHibernateSession session)
        {
            return new ProtocolManager(session);
        }
		public IProtocolCodeManager GetProtocolCodeManager()
        {
            return new ProtocolCodeManager();
        }
		public IProtocolCodeManager GetProtocolCodeManager(INHibernateSession session)
        {
            return new ProtocolCodeManager(session);
        }
		public IProtocolGroupManager GetProtocolGroupManager()
        {
            return new ProtocolGroupManager();
        }
		public IProtocolGroupManager GetProtocolGroupManager(INHibernateSession session)
        {
            return new ProtocolGroupManager(session);
        }
		public IProtocolRejectReasonEnumManager GetProtocolRejectReasonEnumManager()
        {
            return new ProtocolRejectReasonEnumManager();
        }
		public IProtocolRejectReasonEnumManager GetProtocolRejectReasonEnumManager(INHibernateSession session)
        {
            return new ProtocolRejectReasonEnumManager(session);
        }
		public IProtocolStatusEnumManager GetProtocolStatusEnumManager()
        {
            return new ProtocolStatusEnumManager();
        }
		public IProtocolStatusEnumManager GetProtocolStatusEnumManager(INHibernateSession session)
        {
            return new ProtocolStatusEnumManager(session);
        }
		public IProtocolUrgencyEnumManager GetProtocolUrgencyEnumManager()
        {
            return new ProtocolUrgencyEnumManager();
        }
		public IProtocolUrgencyEnumManager GetProtocolUrgencyEnumManager(INHibernateSession session)
        {
            return new ProtocolUrgencyEnumManager(session);
        }
		public IReligionEnumManager GetReligionEnumManager()
        {
            return new ReligionEnumManager();
        }
		public IReligionEnumManager GetReligionEnumManager(INHibernateSession session)
        {
            return new ReligionEnumManager(session);
        }
		public IReportManager GetReportManager()
        {
            return new ReportManager();
        }
		public IReportManager GetReportManager(INHibernateSession session)
        {
            return new ReportManager(session);
        }
		public IReportPartManager GetReportPartManager()
        {
            return new ReportPartManager();
        }
		public IReportPartManager GetReportPartManager(INHibernateSession session)
        {
            return new ReportPartManager(session);
        }
		public IReportPartExtendedPropertyManager GetReportPartExtendedPropertyManager()
        {
            return new ReportPartExtendedPropertyManager();
        }
		public IReportPartExtendedPropertyManager GetReportPartExtendedPropertyManager(INHibernateSession session)
        {
            return new ReportPartExtendedPropertyManager(session);
        }
		public IReportPartStatusEnumManager GetReportPartStatusEnumManager()
        {
            return new ReportPartStatusEnumManager();
        }
		public IReportPartStatusEnumManager GetReportPartStatusEnumManager(INHibernateSession session)
        {
            return new ReportPartStatusEnumManager(session);
        }
		public IReportStatusEnumManager GetReportStatusEnumManager()
        {
            return new ReportStatusEnumManager();
        }
		public IReportStatusEnumManager GetReportStatusEnumManager(INHibernateSession session)
        {
            return new ReportStatusEnumManager(session);
        }
		public IResultCommunicationModeEnumManager GetResultCommunicationModeEnumManager()
        {
            return new ResultCommunicationModeEnumManager();
        }
		public IResultCommunicationModeEnumManager GetResultCommunicationModeEnumManager(INHibernateSession session)
        {
            return new ResultCommunicationModeEnumManager(session);
        }
		public ISexEnumManager GetSexEnumManager()
        {
            return new SexEnumManager();
        }
		public ISexEnumManager GetSexEnumManager(INHibernateSession session)
        {
            return new SexEnumManager(session);
        }
		public ISpokenLanguageEnumManager GetSpokenLanguageEnumManager()
        {
            return new SpokenLanguageEnumManager();
        }
		public ISpokenLanguageEnumManager GetSpokenLanguageEnumManager(INHibernateSession session)
        {
            return new SpokenLanguageEnumManager(session);
        }
		public IStaffManager GetStaffManager()
        {
            return new StaffManager();
        }
		public IStaffManager GetStaffManager(INHibernateSession session)
        {
            return new StaffManager(session);
        }
		public IStaffAddressManager GetStaffAddressManager()
        {
            return new StaffAddressManager();
        }
		public IStaffAddressManager GetStaffAddressManager(INHibernateSession session)
        {
            return new StaffAddressManager(session);
        }
		public IStaffEmailAddressManager GetStaffEmailAddressManager()
        {
            return new StaffEmailAddressManager();
        }
		public IStaffEmailAddressManager GetStaffEmailAddressManager(INHibernateSession session)
        {
            return new StaffEmailAddressManager(session);
        }
		public IStaffExtendedPropertyManager GetStaffExtendedPropertyManager()
        {
            return new StaffExtendedPropertyManager();
        }
		public IStaffExtendedPropertyManager GetStaffExtendedPropertyManager(INHibernateSession session)
        {
            return new StaffExtendedPropertyManager(session);
        }
		public IStaffGroupManager GetStaffGroupManager()
        {
            return new StaffGroupManager();
        }
		public IStaffGroupManager GetStaffGroupManager(INHibernateSession session)
        {
            return new StaffGroupManager(session);
        }
		public IStaffTelephoneNumberManager GetStaffTelephoneNumberManager()
        {
            return new StaffTelephoneNumberManager();
        }
		public IStaffTelephoneNumberManager GetStaffTelephoneNumberManager(INHibernateSession session)
        {
            return new StaffTelephoneNumberManager(session);
        }
		public IStaffTypeEnumManager GetStaffTypeEnumManager()
        {
            return new StaffTypeEnumManager();
        }
		public IStaffTypeEnumManager GetStaffTypeEnumManager(INHibernateSession session)
        {
            return new StaffTypeEnumManager(session);
        }
		public ITelephoneEquipmentEnumManager GetTelephoneEquipmentEnumManager()
        {
            return new TelephoneEquipmentEnumManager();
        }
		public ITelephoneEquipmentEnumManager GetTelephoneEquipmentEnumManager(INHibernateSession session)
        {
            return new TelephoneEquipmentEnumManager(session);
        }
		public ITelephoneUseEnumManager GetTelephoneUseEnumManager()
        {
            return new TelephoneUseEnumManager();
        }
		public ITelephoneUseEnumManager GetTelephoneUseEnumManager(INHibernateSession session)
        {
            return new TelephoneUseEnumManager(session);
        }
		public ITestManager GetTestManager()
        {
            return new TestManager();
        }
		public ITestManager GetTestManager(INHibernateSession session)
        {
            return new TestManager(session);
        }
		public ITranscriptionRejectReasonEnumManager GetTranscriptionRejectReasonEnumManager()
        {
            return new TranscriptionRejectReasonEnumManager();
        }
		public ITranscriptionRejectReasonEnumManager GetTranscriptionRejectReasonEnumManager(INHibernateSession session)
        {
            return new TranscriptionRejectReasonEnumManager(session);
        }
		public IUserManager GetUserManager()
        {
            return new UserManager();
        }
		public IUserManager GetUserManager(INHibernateSession session)
        {
            return new UserManager(session);
        }
		public IUserSessionManager GetUserSessionManager()
        {
            return new UserSessionManager();
        }
		public IUserSessionManager GetUserSessionManager(INHibernateSession session)
        {
            return new UserSessionManager(session);
        }
		public IVisitManager GetVisitManager()
        {
            return new VisitManager();
        }
		public IVisitManager GetVisitManager(INHibernateSession session)
        {
            return new VisitManager(session);
        }
		public IVisitExtendedPropertyManager GetVisitExtendedPropertyManager()
        {
            return new VisitExtendedPropertyManager();
        }
		public IVisitExtendedPropertyManager GetVisitExtendedPropertyManager(INHibernateSession session)
        {
            return new VisitExtendedPropertyManager(session);
        }
		public IVisitLocationManager GetVisitLocationManager()
        {
            return new VisitLocationManager();
        }
		public IVisitLocationManager GetVisitLocationManager(INHibernateSession session)
        {
            return new VisitLocationManager(session);
        }
		public IVisitLocationRoleEnumManager GetVisitLocationRoleEnumManager()
        {
            return new VisitLocationRoleEnumManager();
        }
		public IVisitLocationRoleEnumManager GetVisitLocationRoleEnumManager(INHibernateSession session)
        {
            return new VisitLocationRoleEnumManager(session);
        }
		public IVisitPractitionerManager GetVisitPractitionerManager()
        {
            return new VisitPractitionerManager();
        }
		public IVisitPractitionerManager GetVisitPractitionerManager(INHibernateSession session)
        {
            return new VisitPractitionerManager(session);
        }
		public IVisitPractitionerRoleEnumManager GetVisitPractitionerRoleEnumManager()
        {
            return new VisitPractitionerRoleEnumManager();
        }
		public IVisitPractitionerRoleEnumManager GetVisitPractitionerRoleEnumManager(INHibernateSession session)
        {
            return new VisitPractitionerRoleEnumManager(session);
        }
		public IVisitStatusEnumManager GetVisitStatusEnumManager()
        {
            return new VisitStatusEnumManager();
        }
		public IVisitStatusEnumManager GetVisitStatusEnumManager(INHibernateSession session)
        {
            return new VisitStatusEnumManager(session);
        }
		public IWorklistManager GetWorklistManager()
        {
            return new WorklistManager();
        }
		public IWorklistManager GetWorklistManager(INHibernateSession session)
        {
            return new WorklistManager(session);
        }
		public IWorkQueueExtendedPropertyManager GetWorkQueueExtendedPropertyManager()
        {
            return new WorkQueueExtendedPropertyManager();
        }
		public IWorkQueueExtendedPropertyManager GetWorkQueueExtendedPropertyManager(INHibernateSession session)
        {
            return new WorkQueueExtendedPropertyManager(session);
        }
		public IWorkQueueItemManager GetWorkQueueItemManager()
        {
            return new WorkQueueItemManager();
        }
		public IWorkQueueItemManager GetWorkQueueItemManager(INHibernateSession session)
        {
            return new WorkQueueItemManager(session);
        }
		public IWorkQueueStatusEnumManager GetWorkQueueStatusEnumManager()
        {
            return new WorkQueueStatusEnumManager();
        }
		public IWorkQueueStatusEnumManager GetWorkQueueStatusEnumManager(INHibernateSession session)
        {
            return new WorkQueueStatusEnumManager(session);
        }
        
        #endregion
    }
}
