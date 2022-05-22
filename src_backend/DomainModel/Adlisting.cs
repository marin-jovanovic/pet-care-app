

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class Adlisting
    {
        [Key]
        [Column(Order = 1)]
        public int AdlistingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdAdress { get; set; }
        public string AdlistingDescription { get; set; }
        public double? Price { get; set; }
        public string Title { get; set; }
        public int PetId { get; set; }
        public bool? IsActiv { get; set; }
        //public string sessionId { get; set; }

    }
}