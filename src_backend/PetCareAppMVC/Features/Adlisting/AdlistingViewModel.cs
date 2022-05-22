using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Adlisting
{
    public class AdlistingViewModel
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdAdListing { get; set; }
        public int IdDescriptable { get; set; }

        public string UserName { get; set; }
        public int? IdLocation { get; set; }
        public int? IdPeriod { get; set; }
    }
}
