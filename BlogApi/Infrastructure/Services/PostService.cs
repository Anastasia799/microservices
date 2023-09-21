using AuthApi.Dtos;
using AutoMapper;
using BlogApi.Database;
using BlogApi.Dtos;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApi.Services;

public class PostService : IPostService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;

    public PostService(IMapper mapper, ApplicationDbContext context, ILogger logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<ServiceResult> Delete(Guid id) {
        try {
            var entity = await _context.Posts
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entity == null) {
                return new ServiceResult(false,"Entry not found");
            }

            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync();

            return new ServiceResult(true, "The entry has been removed successfully");
        } catch (Exception ex) {
            _logger.LogError(ex, "Delete entry exception");
            return new ServiceResult(false, ex.Message);
        }
    }

    public async Task<ServiceResult<PostDto>> CreateAsync(PostDto dto) {
        dto.Id = Guid.NewGuid();
        var entity = new PostDto();

        _mapper.Map(dto, entity);

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return new ServiceResult<PostDto>(true,"New entry has been added successfully", _mapper.Map<PostDto>(entity));
    }

    public async Task<ServiceResult<PostDto>> UpdateAsync(PostDto dto) {
        var entity = await GetByIdAsync(dto.Id);

        if (entity == null) {
            return new ServiceResult<PostDto>(false, "Entry not found");
        }

        _mapper.Map(dto, entity);

        await _context.SaveChangesAsync();

        return new ServiceResult<PostDto>(true, "The entry has been updated successfully", _mapper.Map<PostDto>(entity));

    }

    public async Task<Post?> GetByIdAsync(Guid id) {
        var query = _context.Posts
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        return await query.ConfigureAwait(false);
    }
    
}