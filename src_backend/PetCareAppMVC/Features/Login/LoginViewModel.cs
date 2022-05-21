using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Login;

public class LoginViewModel
{

    public int? idPerson { get; set; }

    public string userName { get; set; }

    public string sessionId { get; set; }

    //[Required]
    //[MaxLength(20)]
    //[Display(Name = "Password")]
    public string password { get; set; }
}
