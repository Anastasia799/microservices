using AuthApi.Dtos;

namespace AuthApi.Interfaces;

public interface IUserService
{
    Task<ServiceResult<UserDto>> RegistrationAsync(UserDto dto);
    Task<ServiceResult<UserDto>> AuthorizationAsync(UserDto dto);
}