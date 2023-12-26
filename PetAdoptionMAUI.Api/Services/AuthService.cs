using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared.Dtos;

namespace PetAdoptionMAUI.Api.Services;

public interface IAuthService
{
    Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    Task<ApiResponse> ChangePasswordAsync(int userId, string newPassword);
}

public class AuthService : IAuthService
{
    private readonly PetContext _context;
    private readonly TokenService _tokenService;

    public AuthService(PetContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var dbUser = await _context.Users
                           .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (dbUser is null)
            return ApiResponse<AuthResponseDto>.Fail("User does not exist");

        if (dbUser.Password != dto.Password)
            return ApiResponse<AuthResponseDto>.Fail("Incorrect password");

        var token = _tokenService.GenerateJWT(dbUser);

        return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));
    }

    public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var existingUser = await _context.Users
                                .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser is not null)
            return ApiResponse<AuthResponseDto>.Fail("Email already exist");

        var dbUser = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.Password,
        };
        await _context.Users.AddAsync(dbUser);

        await _context.SaveChangesAsync();

        var token = _tokenService.GenerateJWT(dbUser);

        return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));
    }
    public async Task<ApiResponse> ChangePasswordAsync(int userId, string newPassword)
    {
        var dbUser = await _context.Users
                    .AsTracking()
                    .FirstOrDefaultAsync(u => u.Id == userId);
        if(dbUser is not null)
        {
            dbUser.Password = newPassword;
           await _context.SaveChangesAsync();
            return ApiResponse.Success();
        }
        return ApiResponse.Fail("Invalid request");
    }
}
