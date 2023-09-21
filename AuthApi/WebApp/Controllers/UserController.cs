using AuthApi.Application.Dtos;
using AuthApi.Application.Interfaces;
using AuthApi.Infrastructure.Extentions;
using AuthApi.WebApp.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthApi.WebApp.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ILogger<UserController> _logger;

    public UserController(
        IUserService userService,
        IMapper mapper, 
        ILogger<UserController> logger) {
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IActionResult> Registration(UserViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<UserDto>(viewModel);
            var newUser = await _userService.RegistrationAsync(dto);
            
            return Json(new ServiceResult(true, newUser.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to register user");
            return Json(new ServiceResult(false, exception.Message));
        }
    } 
    
    public async Task<IActionResult> Authorization(UserViewModel? viewModel) {
        try {
            if (viewModel is null)
                return Json(new ServiceResult(true, "User is null"));
            
            if (!ModelState.IsValid)
                return Json(new ServiceResult(false, ModelState.GetErrors()));
            
            var dto = _mapper.Map<UserDto>(viewModel);
            var newUser = await _userService.AuthorizationAsync(dto);
            
            return Json(new ServiceResult(true, newUser.Message));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An error occured while trying to log in user");
            return Json(new ServiceResult(false, exception.Message));
        }
    }
}