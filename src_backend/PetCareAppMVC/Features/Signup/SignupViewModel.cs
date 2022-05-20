using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Signup;

public class SignupViewModel
{
    public string username { get; set; }
    public string oib { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string cardnumber { get; set; }
    public string cardtype { get; set; }
    public string cardmonth { get; set; }
    public string cardyear { get; set; }
    public string password { get; set; }
    public string passwordrepeat { get; set; }


}
