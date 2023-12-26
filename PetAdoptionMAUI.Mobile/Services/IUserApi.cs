using PetAdoptionMAUI.Shared.Dtos;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services;

[Headers("Authorization: Bearer")]
public interface IUserApi
{
    [Post("/api/user/adopt/{petId}")]
    Task<ApiResponse> AdoptPetAsync(int petId);

    [Get("/api/user/adoptions")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserAdoptionsAsync();

    [Get("/api/user/favorites")]
    Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserFavoritesAsync();

    [Post("/api/user/favorites/{petId}")]
    Task<ApiResponse> ToggleFavoritesAsync(int petId);

    [Get("/api/user/view-pet-details/{petId}")]
    Task<Shared.Dtos.ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId);

    [Post("/api/user/change-password")]
    Task<ApiResponse> ChangePasswordAsync(SingleValueDto<string> newPassword);
}