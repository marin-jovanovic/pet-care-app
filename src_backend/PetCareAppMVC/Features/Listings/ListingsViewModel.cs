using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Login;

public class ListingsViewModel
{
    public int? idPerson { get; set; }

    public string Description { get; set; }

    //[Required]
    //[MaxLength(25)]

    public string ListingId { get; set; }

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
}
