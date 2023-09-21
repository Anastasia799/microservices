using AuthApi.Application.Dtos;
using AuthApi.Domain.Models;
using AuthApi.WebApp.ViewModels;
using AutoMapper;

namespace AuthApi.WebApp.AutoMapperConfigurations;

public class UserProfile : Profile
{
    public UserProfile() {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, UserViewModel>();
    }
}