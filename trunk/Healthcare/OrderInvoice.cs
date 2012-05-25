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
    public class OrderInvoices : ClearCanvas.Enterprise.Core.Entity
    {

        #region Constructors

        /// <summary>
        /// Default no-args constructor required by NHibernate
        /// </summary>
        public OrderInvoices()
        {
        }
        /// <summary>
        /// All fields constructor
        /// </summary>
        public OrderInvoices(Order o, string invoicenumber, decimal totalcollect,
            decimal totalinsurance,
            decimal totaldiscount,
            string listProcedures,
            bool isfinished,
            bool deactivated)
            : base()
        {
            InvoiceOrder = o;
            TotalCollect = totalcollect;
            TotalInsurance = totalinsurance;
            TotalDiscount = totaldiscount;
            IsCollectedInsurance = isfinished;
            ListProcedures = listProcedures;
            Deactivated = deactivated;
        }


        #endregion

        #region Public Properties


        [PersistentProperty]
        [Unique]
        public virtual Order InvoiceOrder { get; set; }

        [PersistentProperty]
        [Length(50)]
        [Unique]
        public virtual string InvoiceNumber { get; set; }

        [PersistentProperty]
        public virtual bool Deactivated { get; set; }

        [PersistentProperty]
        public virtual decimal TotalCollect { get; set; }

        [PersistentProperty]
        public virtual decimal TotalInsurance { get; set; }

        [PersistentProperty]
        public virtual decimal TotalWaitingAmount { get; set; }

        [PersistentProperty]
        public virtual decimal TotalDiscount { get; set; }

        [PersistentProperty]
        public virtual bool IsCollectedInsurance { get; set; }

        [PersistentProperty]
        public virtual string CreatedUser { get; set; }

        [PersistentProperty]
        public virtual decimal TotalReceived { get; set; }

        [PersistentProperty]
        public virtual decimal TotalChanges { get; set; }
        [PersistentProperty]
        public virtual DateTime CreatedDate { get; set; }
        [PersistentProperty]
        [Length(65000)]
        public virtual string ListProcedures { get; set; }
        #endregion
    }
}
