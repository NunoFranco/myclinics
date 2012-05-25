// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Enterprise.Authentication
{

    /// <summary>
    /// Search criteria for <see cref="UserSession"/> class.
    /// </summary>
	public partial class UserSessionSearchCriteria : EntitySearchCriteria<UserSession>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public UserSessionSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public UserSessionSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected UserSessionSearchCriteria(UserSessionSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new UserSessionSearchCriteria(this);
        }


		
	  	public ClearCanvas.Enterprise.Authentication.UserSearchCriteria User
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("User"))
	  			{
	  				this.SubCriteria["User"] = new ClearCanvas.Enterprise.Authentication.UserSearchCriteria("User");
	  			}
	  			return (ClearCanvas.Enterprise.Authentication.UserSearchCriteria)this.SubCriteria["User"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> HostName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("HostName"))
	  			{
	  				this.SubCriteria["HostName"] = new SearchCondition<string>("HostName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["HostName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Application
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Application"))
	  			{
	  				this.SubCriteria["Application"] = new SearchCondition<string>("Application");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Application"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> SessionId
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SessionId"))
	  			{
	  				this.SubCriteria["SessionId"] = new SearchCondition<string>("SessionId");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["SessionId"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> CreationTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreationTime"))
	  			{
	  				this.SubCriteria["CreationTime"] = new SearchCondition<DateTime>("CreationTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["CreationTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> ExpiryTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ExpiryTime"))
	  			{
	  				this.SubCriteria["ExpiryTime"] = new SearchCondition<DateTime>("ExpiryTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["ExpiryTime"];
	  		}
	  	}
	  	
	}
}
