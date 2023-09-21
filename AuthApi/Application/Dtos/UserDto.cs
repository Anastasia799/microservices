using Microsoft.AspNetCore.Identity;

namespace AuthApi.Application.Dtos;

public class UserDto : IdentityUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}