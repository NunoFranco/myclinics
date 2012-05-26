using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Location : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _id = String.Empty;
		private string _name = String.Empty;
		private string _description = null;
		private string _building = null;
		private string _floor = null;
		private string _pointOfCare = null;
		private string _room = null;
		private string _bed = null;
		private bool _deactivated = default(Boolean);
		
		private Facility _facility = null;
		
		private IList<Visit> _visits = new List<Visit>();
		private IList<VisitLocation> _visitLocations = new List<VisitLocation>();
		
		#endregion

        #region Constructors

        public Location() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_id);
			sb.Append(_name);
			sb.Append(_description);
			sb.Append(_building);
			sb.Append(_floor);
			sb.Append(_pointOfCare);
			sb.Append(_room);
			sb.Append(_bed);
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
		
		public virtual string Name
        {
            get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				OnNameChanged();
			}
        }
		partial void OnNameChanging();
		partial void OnNameChanged();
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual string Building
        {
            get { return _building; }
			set
			{
				OnBuildingChanging();
				_building = value;
				OnBuildingChanged();
			}
        }
		partial void OnBuildingChanging();
		partial void OnBuildingChanged();
		
		public virtual string Floor
        {
            get { return _floor; }
			set
			{
				OnFloorChanging();
				_floor = value;
				OnFloorChanged();
			}
        }
		partial void OnFloorChanging();
		partial void OnFloorChanged();
		
		public virtual string PointOfCare
        {
            get { return _pointOfCare; }
			set
			{
				OnPointOfCareChanging();
				_pointOfCare = value;
				OnPointOfCareChanged();
			}
        }
		partial void OnPointOfCareChanging();
		partial void OnPointOfCareChanged();
		
		public virtual string Room
        {
            get { return _room; }
			set
			{
				OnRoomChanging();
				_room = value;
				OnRoomChanged();
			}
        }
		partial void OnRoomChanging();
		partial void OnRoomChanged();
		
		public virtual string Bed
        {
            get { return _bed; }
			set
			{
				OnBedChanging();
				_bed = value;
				OnBedChanged();
			}
        }
		partial void OnBedChanging();
		partial void OnBedChanged();
		
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
		
		public virtual Facility Facility
        {
            get { return _facility; }
			set
			{
				OnFacilityChanging();
				_facility = value;
				OnFacilityChanged();
			}
        }
		partial void OnFacilityChanging();
		partial void OnFacilityChanged();
		
		public virtual IList<Visit> Visits
        {
            get { return _visits; }
            set
			{
				OnVisitsChanging();
				_visits = value;
				OnVisitsChanged();
			}
        }
		partial void OnVisitsChanging();
		partial void OnVisitsChanged();
		
		public virtual IList<VisitLocation> VisitLocations
        {
            get { return _visitLocations; }
            set
			{
				OnVisitLocationsChanging();
				_visitLocations = value;
				OnVisitLocationsChanged();
			}
        }
		partial void OnVisitLocationsChanging();
		partial void OnVisitLocationsChanged();
		
        #endregion
    }
}
