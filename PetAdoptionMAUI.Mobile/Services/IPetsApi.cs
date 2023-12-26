using PetAdoptionMAUI.Shared.Dtos;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services;

public interface IPetsApi
{
    [Get("/api/pets")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetAllPetsAsync();

    [Get("/api/pets/new/{count}")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count);

    [Get("/api/pets/popular/{count}")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count);

    [Get("/api/pets/random/{count}")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count);

    [Get("/api/pets/{petId}")]
    Task<Shared.Dtos.ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId);
}
