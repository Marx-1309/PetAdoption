using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionMAUI.Api.Services;
using PetAdoptionMAUI.Shared.Dtos;
using System.Security.Claims;

namespace PetAdoptionMAUI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserPetService _userPetService;
    private readonly IPetService _petService;
    private readonly IAuthService _authService;

    public UserController(IUserPetService userPetService, IPetService petService, IAuthService authService)
    {
        _userPetService = userPetService;
        _petService = petService;
        _authService = authService;
    }

    private int UserId => 
        Convert.ToInt32(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

    // api/user/adopt/1
    [HttpPost("adopt/{petId:int}")]
    public async Task<ApiResponse> AdoptPetAsync(int petId) =>
        await _userPetService.AdoptPetAsync(UserId, petId);

    //  api/user/adoptions
    [HttpGet("adoptions")]
    public async Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync() =>
        await _userPetService.GetUserAdoptionsAsync(UserId);

    //  api/user/favorites
    [HttpGet("favorites")]
    public async Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync() =>
        await _userPetService.GetUserFavoritesAsync(UserId);

    //  api/user/favorites/1
    [HttpPost("favorites/{petId:int}")]
    public async Task<ApiResponse> ToggleFavoritesAsync(int petId) =>
        await _userPetService.ToggleFavoritesAsync(UserId, petId);

    //  api/user/view-pet-details/1
    [HttpGet("view-pet-details/{petId:int}")]
    public async Task<ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId) =>
        await _petService.GetPetDetailsAsync(petId, UserId);

    [HttpPost("change-password")]
    public async Task<ApiResponse> ChangePassword(SingleValueDto<string> newPassword) =>
        await _authService.ChangePasswordAsync(UserId, newPassword.Value);
}