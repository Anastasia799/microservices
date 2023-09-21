using AuthApi.Dtos;
using BlogApi.Dtos;
using BlogApi.Models;

namespace BlogApi.Interfaces;

public interface IPostService {
    Task<ServiceResult> Delete(Guid id);
    Task<ServiceResult<PostDto>> CreateAsync(PostDto dto);
    Task<ServiceResult<PostDto>> UpdateAsync(PostDto dto);
    Task<Post?> GetByIdAsync(Guid id);
}