using AutoMapper;
using BlogApi.Dtos;
using BlogApi.Models;
using BlogApi.WebApp.ViewModels;

namespace BlogApi.WebApp.AutoMapperConfigurations;

public class PostProfile : Profile
{
    public PostProfile() {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, PostViewModel>();
    }
}