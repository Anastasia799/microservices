using AuthApi.Dtos;
using AuthApi.Models;
using AuthApi.ViewModels;
using AutoMapper;

namespace AuthApi.AutoMapperConfigurations;

public class UserProfile : Profile
{
    public UserProfile() {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, UserViewModel>();
    }
}