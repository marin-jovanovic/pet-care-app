using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features;

public class PersonViewModel
{
  public int? idPerson { get; set; }
  [Required]
  [MaxLength(25)] 
  [Display(Name="First Name")]
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
  public string username { get; set; }
}
