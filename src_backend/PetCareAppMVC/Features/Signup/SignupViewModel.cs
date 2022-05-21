using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Signup;

public class SignupViewModel
{
    [Required(ErrorMessage = "The Encaissment ID must be submitted")]
    public int PersonId { get; set; }
    public string PersonFirstName { get; set; }
    public string PersonLastName { get; set; }
    public string Oib { get; set; }
    public string PersonEmail { get; set; }
    public string PersonMobile { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SessionId { get; set; }



}
