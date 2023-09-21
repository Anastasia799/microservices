using Microsoft.AspNetCore.Identity;

namespace AuthApi.Domain.Models;

public class User : IdentityUser<Guid>
{
}