
namespace Domain
{
    public partial class Adress
    {
      
        public int AdressId { get; set; }
        public string Adress1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool? IsHouse { get; set; }
        public int? Floor { get; set; }

       
    }
}