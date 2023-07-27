using System.Collections.Generic;

namespace Advice.UI.Client.ViewModels
{
    public record class ProjectSpecificationViewModel
    {
        public RealEstateViewModel RealEstateViewModel { get; set; }
        public SalesDetailsViewModel SalesDetailsViewModel { get; set; }
        public List<VastgoedEigendomsRechtViewModel> VastgoedEigendomsRechtViewModels { get; set; }
        public AndereAankoopKostenViewModel AndereAankoopKostenViewModel { get; set; }
        public VerbouwingsParametersViewModel VerbouwingsParametersViewModel { get; set; }
    }
}