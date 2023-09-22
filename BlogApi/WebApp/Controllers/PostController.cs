using AuthApi.Dtos;
using AutoMapper;
using BlogApi.Dtos;
using BlogApi.Extentions;
using BlogApi.Interfaces;
using BlogApi.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;
    private readonly ILogger<PostController> _logger;

    public PostController(
        IPostService postService, 
        IMapper mapper, 
        ILogger<PostController> logger) {
        _postService = postService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PostViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<PostDto>(viewModel);
            var post = await _postService.CreateAsync(dto);
            
            return Json(new ServiceResult(true, post.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to create post");
            return Json(new ServiceResult(false, exception.Message));
        }
    } 
    
    [HttpGet]
    public async Task<IActionResult> Update(Guid postId) {
        var post = await _postService.GetByIdAsync(postId);
        return View(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(PostViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<PostDto>(viewModel);
            var post = await _postService.UpdateAsync(dto);
            
            return Json(new ServiceResult(true, post.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to update post");
            return Json(new ServiceResult(false, exception.Message));
        }
    }  
    
    [HttpDelete]
    public async Task<IActionResult> Delete(PostViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<PostDto>(viewModel);
            var post = await _postService.Delete(dto.Id);
            
            return Json(new ServiceResult(true, post.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to delete post");
            return Json(new ServiceResult(false, exception.Message));
        }
    } 
    
    [HttpGet]
    public async Task<IActionResult> GetById(PostViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<PostDto>(viewModel);
            var post = await _postService.GetByIdAsync(dto.Id);

            return Json(post != null ? new ServiceResult(true, $"User received by id: {post.Id}") : new ServiceResult(false, $"User not found"));
        } catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to delete post");
            return Json(new ServiceResult(false, exception.Message));
        }
    }  
}