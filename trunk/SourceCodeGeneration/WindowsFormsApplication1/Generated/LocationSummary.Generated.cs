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
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.Location
{
    [DataContract]
    public partial class LocationSummary : DataContractBase, IEquatable<LocationSummary>
    {
        public LocationSummary(EntityRef entityRef ,string _id,
string _name,
string _description,
string _building,
string _floor,
string _pointofcare,
string _room,
string _bed,
bool _deactivated,
FacilitySummary _facility)
        {
            this.objRef = entityRef;
			Id = _id;
Name = _name;
Description = _description;
Building = _building;
Floor = _floor;
PointOfCare = _pointofcare;
Room = _room;
Bed = _bed;
Deactivated = _deactivated;
Facility = _facility;

			
			CustomConstructor();
        }

		public LocationSummary()
		{
			CustomConstructor();
		}

        [DataMember]
        public EntityRef objRef;

        [DataMember]
public string Id;
[DataMember]
public string Name;
[DataMember]
public string Description;
[DataMember]
public string Building;
[DataMember]
public string Floor;
[DataMember]
public string PointOfCare;
[DataMember]
public string Room;
[DataMember]
public string Bed;
[DataMember]
public bool Deactivated;
[DataMember]
public FacilitySummary Facility;


		public bool Equals(LocationSummary that)
        {
            if (that == null) return false;
            return Equals(this.objRef, that.objRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as LocationSummary);
        }

        public override int GetHashCode()
        {
            return objRef.GetHashCode();
        }
    }
}