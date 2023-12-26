using PetAdoptionMAUI.Shared.Dtos;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services;
public interface IAuthApi
{
    [Post("/api/auth/login")]
    Task<Shared.Dtos.ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);

    [Post("/api/auth/register")]
    Task<Shared.Dtos.ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
}
