using AuthApi.Dtos;
using BlogApi.Dtos;

namespace BlogApi.Interfaces;

public interface ICommentService
{
    Task<ServiceResult<CommentDto>> CreateAsync(CommentDto dto);
}