using System.ComponentModel.DataAnnotations;

namespace AuthApi.WebApp.ViewModels;

public class UserViewModel
{
    [Required]
    [Display(Name = "Email")] public string Email { get; set; }
        
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")] public string Password { get; set; }
        
        
    [Required]
    [Display(Name = "Phone Number")] public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    [Display(Name = "Login")]  public string Login { get; set; }
}