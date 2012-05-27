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
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Common.Admin.UserAdmin;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.WorkingShiftAdmin;
using ClearCanvas.Ris.Application.Common.Admin.FacilityAdmin;

namespace ClearCanvas.Ris.Client.Admin
{
	/// <summary>
	/// Defines an interface for providing custom editing pages to be displayed in the WorkingShift editor.
	/// </summary>
	public interface IWorkingShiftPageProvider : IExtensionPageProvider<IWorkingShiftPage, IWorkingShiftContext>
	{
	}

	/// <summary>
	/// Defines an interface for providing a custom editor page with access to the editor
	/// context.
	/// </summary>
	public interface IWorkingShiftContext
	{
		EntityRef WorkingShiftRef { get; }

	}

	/// <summary>
	/// Defines an interface to a custom WorkingShift editor page.
	/// </summary>
	public interface IWorkingShiftPage : IExtensionPage
	{
		void Save();
	}

	/// <summary>
	/// Defines an extension point for adding custom pages to the WorkingShift editor.
	/// </summary>
	public class WorkingShiftPageProviderExtensionPoint : ExtensionPoint<IWorkingShiftPageProvider>
	{
	}



	/// <summary>
	/// Allows editing of WorkingShift person information.
	/// </summary>
	public class WorkingShiftComponent : NavigatorComponentContainer
	{
		#region WorkingShiftContext

		class EditorContext : IWorkingShiftContext
		{
			private readonly WorkingShiftComponent _owner;

			public EditorContext(WorkingShiftComponent owner)
			{
				_owner = owner;
			}

			public EntityRef WorkingShiftRef
			{
				get { return _owner._WorkingShiftRef; }
			}

		}

		#endregion


		private EntityRef _WorkingShiftRef;
		private WorkingShiftDetail _WorkingShiftDetail;

		//private string _originalWorkingShiftUserName;

		// return values for WorkingShift
		private WorkingShiftSummary _WorkingShiftSummary;

		private readonly bool _isNew;

        //private EmailAddressesSummaryComponent _emailAddressesSummary;
        //private PhoneNumbersSummaryComponent _phoneNumbersSummary;
        //private AddressesSummaryComponent _addressesSummary;

		private WorkingShiftEditorComponent _detailsEditor;
        private WorkingShiftStaffAssignment _doctorsEditor;
        //private WorkingShiftWorkingShiftGroupEditorComponent _nonElectiveGroupsEditor;
        //private WorkingShiftWorkingShiftGroupEditorComponent _electiveGroupsEditor;
        //private WorkingShiftClinicsEditorComponent _WorkingShiftclinicEditor;

		private List<IWorkingShiftPage> _extensionPages;

		/// <summary>
		/// Constructs an editor to edit a new WorkingShift
		/// </summary>
		public WorkingShiftComponent()
		{
			_isNew = true;
		}

		/// <summary>
		/// Constructs an editor to edit an existing WorkingShift profile
		/// </summary>
		/// <param name="reference"></param>
		public WorkingShiftComponent(EntityRef reference)
		{
			_isNew = false;
			_WorkingShiftRef = reference;
		}


        //public List<FacilitySummary> AllFacilitiesChoices { get{
        //     List<FacilitySummary> facilities = new List<FacilitySummary>();
        //    Platform.GetService<IFacilityAdminService>(
        //                           delegate(IFacilityAdminService service)
        //                           {
        //                               facilities = service.ListAllFacilities(new ListAllFacilitiesRequest()).Facilities;
        //                           }
        //                        );
        //    return facilities ;
        //} }

		/// <summary>
		/// Gets summary of WorkingShift that was added or edited
		/// </summary>
		public WorkingShiftSummary WorkingShiftSummary
		{
			get { return _WorkingShiftSummary; }
		}

		public override void Start()
		{
			Platform.GetService<IWorkingShiftAdminService>(
				delegate(IWorkingShiftAdminService service)
				{
                    LoadWorkingShiftEditorFormDataResponse formDataResponse = service.LoadWorkingShiftEditorFormData(new LoadWorkingShiftEditorFormDataRequest(LoginSession.Current.WorkingFacility.FacilityRef ));

					this.ValidationStrategy = new AllComponentsValidationStrategy();

					if (_isNew)
					{
						_WorkingShiftDetail = new WorkingShiftDetail();
                        _WorkingShiftDetail.Clinic = LoginSession.Current.WorkingFacility;
					}
					else
					{
						LoadWorkingShiftForEditResponse response = service.LoadWorkingShiftForEdit(new LoadWorkingShiftForEditRequest(_WorkingShiftRef));
                        _WorkingShiftRef = response.WorkingShiftdetail.WorkingShiftRef;
                        _WorkingShiftDetail = response.WorkingShiftdetail;
					}

					_detailsEditor = new WorkingShiftEditorComponent()
					                 	{ Detail  = _WorkingShiftDetail};
					this.Pages.Add(new NavigatorPage(SR.WorkingShiftPageName , _detailsEditor));

                    _doctorsEditor = new WorkingShiftStaffAssignment(formDataResponse.staffs );

                    this.Pages.Add(new NavigatorPage(SR.WorkingShiftStaffAssignmentPageName, _doctorsEditor));

                    //_addressesSummary = new AddressesSummaryComponent(formDataResponse.AddressTypeChoices)
                    //                        {
                    //                            ReadOnly = !CanModifyWorkingShiftProfile,
                    //                            SetModifiedOnListChange = true,
                    //                            Subject = _WorkingShiftDetail.Addresses
                    //                        };
                    //this.Pages.Add(new NavigatorPage(SR.WorkingShiftAddressPageName , _addressesSummary));

                    //_emailAddressesSummary = new EmailAddressesSummaryComponent
                    //                            {
                    //                                ReadOnly = !CanModifyWorkingShiftProfile,
                    //                                SetModifiedOnListChange = true,
                    //                                Subject = _WorkingShiftDetail.EmailAddresses
                    //                            };
                    //this.Pages.Add(new NavigatorPage(SR.WorkingShiftEmailPageName , _emailAddressesSummary));



                    //// allow modification of non-elective groups only iff the user has WorkingShiftGroup admin permissions
                    //this.Pages.Add(new NavigatorPage(SR.WorkingShiftGroupdNonElectivePageName , _nonElectiveGroupsEditor = new WorkingShiftNonElectiveWorkingShiftGroupEditorComponent(_WorkingShiftDetail.Groups, formDataResponse.WorkingShiftGroupChoices, !CanModifyNonElectiveGroups)));
                    //this.Pages.Add(new NavigatorPage(SR.WorkingShiftGroupdElectivePageName , _electiveGroupsEditor = new WorkingShiftElectiveWorkingShiftGroupEditorComponent(_WorkingShiftDetail.Groups, formDataResponse.WorkingShiftGroupChoices, !CanModifyWorkingShiftProfile)));

                    //this.Pages.Add(new NavigatorPage(SR.WorkingShiftClinicsPageName, _WorkingShiftclinicEditor = new WorkingShiftClinicsEditorComponent(_WorkingShiftDetail.Clinics, AllFacilitiesChoices, !CanModifyWorkingShiftProfile)));
				});

			// instantiate all extension pages
			_extensionPages = new List<IWorkingShiftPage>();
			foreach (IWorkingShiftPageProvider pageProvider in new WorkingShiftPageProviderExtensionPoint().CreateExtensions())
			{
				_extensionPages.AddRange(pageProvider.GetPages(new EditorContext(this)));
			}

			// add extension pages to navigator
			// the navigator will start those components if the user goes to that page
			foreach (IWorkingShiftPage page in _extensionPages)
			{
				this.Pages.Add(new NavigatorPage(page.Path, page.GetComponent()));
			}

			base.Start();
		}

		public override void Accept()
		{
			if (this.HasValidationErrors)
			{
				this.ShowValidation(true);
				return;
			}

			try
			{
				// give extension pages a chance to save data prior to commit
				_extensionPages.ForEach(delegate(IWorkingShiftPage page) { page.Save(); });


				// add or update WorkingShift
				Platform.GetService<IWorkingShiftAdminService>(
					delegate(IWorkingShiftAdminService service)
					{
						if (_isNew)
						{
                            AddWorkingShiftResponse response = service.AddWorkingShift(new AddWorkingShiftRequest(_WorkingShiftDetail));
							_WorkingShiftRef = response.WorkingShift.WorkingShiftRef;
							_WorkingShiftSummary = response.WorkingShift;
						}
						else
						{
							UpdateWorkingShiftResponse response = service.UpdateWorkingShift(new UpdateWorkingShiftRequest(_WorkingShiftDetail));
							_WorkingShiftRef = response.WorkingShift.WorkingShiftRef;
							_WorkingShiftSummary = response.WorkingShift;
						}
					});

				

				this.Exit(ApplicationComponentExitCode.Accepted);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, SR.ExceptionSaveWorkingShift, this.Host.DesktopWindow,
					delegate
					{
						this.ExitCode = ApplicationComponentExitCode.Error;
						this.Host.Exit();
					});
			}
		}

		internal static void UpdateUserAccount(string userName, WorkingShiftSummary WorkingShift)
		{
			if(!string.IsNullOrEmpty(userName))
			{
				Platform.GetService<IUserAdminService>(
					delegate(IUserAdminService service)
					{
						// check if the user account exists
                        ListUsersRequest request = new ListUsersRequest(Enterprise.Common.Common.CurrentLoginUserProfile.CurrentClinicCode );
						request.UserName = userName;
						request.ExactMatchOnly = true;
						UserSummary user = CollectionUtils.FirstElement(service.ListUsers(request).Users);

						if(user != null)
						{
							// modify the display name on the user account
							UserDetail detail = service.LoadUserForEdit(
								new LoadUserForEditRequest(userName)).UserDetail;
							detail.DisplayName = (WorkingShift == null) ? null : WorkingShift.Name.ToString();

							service.UpdateUser(new UpdateUserRequest(detail));
						}
					});
			}
		}

		private static bool CanModifyWorkingShiftProfile
		{
			get
			{
				// require either WorkingShift Admin or WorkingShiftProfile.Update token
				return Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift);
			}
		}

        //private static bool CanModifyNonElectiveGroups
        //{
        //    get
        //    {
        //        // require both WorkingShift and WorkingShiftGroup admin tokens
        //        return Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift)
        //            && Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShiftGroup);
        //    }
        //}

	}
}
