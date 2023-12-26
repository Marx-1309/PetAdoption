using Microsoft.AspNetCore.Mvc;
using PetAdoptionMAUI.Api.Services;
using PetAdoptionMAUI.Shared.Dtos;

namespace PetAdoptionMAUI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IPetService _petService;

    public PetsController(IPetService petService)
    {
        _petService = petService;
    }

    //  api/pets
    [HttpGet("")]
    public async Task<ApiResponse<PetListDto[]>> GetAllPetsAsync() =>
        await _petService.GetAllPetsAsync();

    //  api/pets/new/5
    [HttpGet("new/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count) =>
        await _petService.GetNewlyAddedPetsAsync(count);

    //  api/pets/popular/5
    [HttpGet("popular/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count) =>
        await _petService.GetPopularPetsAsync(count);

    //  api/pets/random/5
    [HttpGet("random/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count) =>
        await _petService.GetRandomPetsAsync(count);


    //  api/pets/1
    [HttpGet("{petId:int}")]
    public async Task<ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId) =>
        await _petService.GetPetDetailsAsync(petId);
}
