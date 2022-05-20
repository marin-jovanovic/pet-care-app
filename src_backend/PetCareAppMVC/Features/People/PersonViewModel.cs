using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.People;

public class PersonViewModel
{
  public int? idPerson { get; set; }

  public string userName { get; set; }
  
  [Required]
  [MaxLength(25)]

  public string mobileNumber { get; set; }
  
  [Required]
  [MaxLength(50)]
  [EmailAddress]
  [Display(Name = "Email")]
  public string email{ get; set; }
  
  [Required]
  [MaxLength(20)]
  [Display(Name = "Password")]
    public string password { get; set; }
}
