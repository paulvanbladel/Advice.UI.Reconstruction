using System;

namespace Advice.UI.Client.ViewModels;

public class CrmCustomer
{
    public Guid CustomerId { get; set; }
    public string CustomerDisplayValue { get; set; }
    public CustomerDefaultLanguage CustomerDefaultLanguage { get; set; }
}
