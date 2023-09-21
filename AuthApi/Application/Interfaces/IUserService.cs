using AuthApi.Application.Dtos;

namespace AuthApi.Application.Interfaces;

public interface IUserService
{
    Task<ServiceResult<UserDto>> RegistrationAsync(UserDto dto);
    Task<ServiceResult<UserDto>> AuthorizationAsync(UserDto dto);
}