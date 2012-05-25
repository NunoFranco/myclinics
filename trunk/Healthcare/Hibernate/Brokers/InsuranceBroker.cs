using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Healthcare.Brokers;
namespace ClearCanvas.Healthcare.Hibernate.Brokers
{
      /// <summary>
    /// NHibernate implementation of <see cref="IDiscountInsuranceBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
    public partial class InsuranceBroker : EntityBroker<InsuranceRule, InsuranceRuleSearchCriteria>, IInsuranceRuleBroker
    {
    }
}
