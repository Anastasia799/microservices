using AutoMapper;
using BlogApi.Dtos;
using BlogApi.Models;
using BlogApi.ViewModels;

namespace BlogApi.AutoMapperConfigurations;

public class PostProfile : Profile
{
    public PostProfile() {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, PostViewModel>();
    }
}