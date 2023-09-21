using AuthApi.Dtos;
using AuthApi.Infrastructure.Database;
using AutoMapper;
using BlogApi.Dtos;
using BlogApi.Interfaces;

namespace BlogApi.Services;

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CommentService(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResult<CommentDto>> CreateAsync(CommentDto dto)
    {
        dto.Id = Guid.NewGuid();
        var entity = new PostDto();

        _mapper.Map(dto, entity);

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return new ServiceResult<CommentDto>(true,"New entry has been added successfully", _mapper.Map<CommentDto>(entity));
    }
}