// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;

namespace ClearCanvas.Healthcare
{
    public class Currency : ClearCanvas.Enterprise.Core.Entity
    {

        #region Constructors

        /// <summary>
        /// Default no-args constructor required by NHibernate
        /// </summary>
        public Currency()
        {
        }
       


        #endregion

        #region Public Properties


        [PersistentProperty]
        [Length(10)]
        [Unique]
        public virtual String CurrencyCode { get; set; }

        [PersistentProperty]
        [Length(50)]
        [Unique]
        public virtual string CurrencyName { get; set; }

        [PersistentProperty]
        public virtual bool Deactivated { get; set; }

        [PersistentProperty]
        public virtual decimal RateToPrimaryExRate { get; set; }

        [PersistentProperty]
        [Length(50)]
        public virtual string DisplayLocale { get; set; }

        [PersistentProperty]
        [Length(50)]
        public virtual string CustomDisplayFormat { get; set; }

        [PersistentProperty]
        public virtual bool IsPrimaryCurrency { get; set; }

        [PersistentProperty]
        public virtual bool IsPrimaryExRateCurrency { get; set; }

        [PersistentProperty]
        public virtual string CreatedUser { get; set; }

        [PersistentProperty]
        public virtual DateTime CreatedOn { get; set; }

        [PersistentProperty]
        public virtual DateTime LastUpdated { get; set; }

        #endregion
    }
}
