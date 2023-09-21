using AuthApi.Application.Dtos;
using AuthApi.Application.Interfaces;
using AuthApi.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<ServiceResult<UserDto>> RegistrationAsync(UserDto dto)
    {
        var user = new User {
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };
        
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return new ServiceResult<UserDto>(true,"New user has been added successfully", _mapper.Map<UserDto>(user));
        }
        return new ServiceResult<UserDto>(false,"Error when creating a user", _mapper.Map<UserDto>(user));
    }

    public async Task<ServiceResult<UserDto>> AuthorizationAsync(UserDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email) ?? await _userManager.FindByNameAsync(dto.Email);
            
        var result = await _signInManager.PasswordSignInAsync(
            user,
            dto.Password,
            dto.RememberMe,
            false
        );
        
        if (result.Succeeded)
        {
            return new ServiceResult<UserDto>(false,"LogIn successfully", _mapper.Map<UserDto>(user));
        }

        return new ServiceResult<UserDto>(false,"Error when LogIn", _mapper.Map<UserDto>(user));
    }
}