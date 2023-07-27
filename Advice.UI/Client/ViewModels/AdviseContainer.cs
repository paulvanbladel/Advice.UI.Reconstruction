
using System;
using System.Collections.Generic;

namespace Advice.UI.Client.ViewModels;

public class AdviseContainer
{
    public Guid AdviseContainerId { get; set; } = Guid.Empty;
    public string AdviseShortDescription { get; set; }
    public IList<CrmCustomer> CrmCustomers { get; set; } = new List<CrmCustomer> {
                 new CrmCustomer
                 {
                     CustomerDefaultLanguage = CustomerDefaultLanguage.Nederlands, CustomerDisplayValue = "Joske Vermeulen"
                 },
                 new CrmCustomer
                 {
                     CustomerDefaultLanguage = CustomerDefaultLanguage.Nederlands, CustomerDisplayValue = "Jeanne Vermeulen"
                 }
            };

    public ProjectSpecificationViewModel ProjectSpecificationViewModel { get; set; }
}
