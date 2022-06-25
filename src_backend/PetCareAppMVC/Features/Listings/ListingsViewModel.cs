using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Listings;

public class ListingsViewModel
{
    public int? idPerson { get; set; }

    public int ListingId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? IdAdress { get; set; }
    public string AdlistingDescription { get; set; }
    public double? Price { get; set; }
    public string Title { get; set; }
    public int PetId { get; set; }
    public bool? IsActiv { get; set; }

    //[Required]
    //[MaxLength(50)]
    //[EmailAddress]
    //[Display(Name = "Email")]
    public string email { get; set; }

    //[Required]
    //[MaxLength(20)]
    //[Display(Name = "Password")]
    public string password { get; set; }

    public string sessionId { get; set; }


    public string PetName { get; set; }
    public bool? Sex { get; set; }
    public string Size { get; set; }
    public string PetType { get; set; }
    public string Breed { get; set; }

    public int AdressId { get; set; }
    public string Adress1 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public bool? IsHouse { get; set; }
    public int? Floor { get; set; }





}
