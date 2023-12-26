using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMAUI.Shared.Dtos;

public class RegisterRequestDto : LoginRequestDto
{
    [Required]
    public string Name { get; set; }
}
