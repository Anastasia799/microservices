using AuthApi.Dtos;
using AuthApi.Infrastructure.Extentions;
using AutoMapper;
using BlogApi.Dtos;
using BlogApi.Interfaces;
using BlogApi.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CommentController(
        ICommentService commentService, 
        IMapper mapper, ILogger logger) {
        _commentService = commentService;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<CommentDto>(viewModel);
            var comment = await _commentService.CreateAsync(dto);
            
            return Json(new ServiceResult(true, comment.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to create post");
            return Json(new ServiceResult(false, exception.Message));
        }
    }
}