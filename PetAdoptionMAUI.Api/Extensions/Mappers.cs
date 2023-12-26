using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared;
using PetAdoptionMAUI.Shared.Dtos;

namespace PetAdoptionMAUI.Api.Extensions;

public static class Mappers
{
    public static PetDetailDto MapToPetDetailsDto(this Pet p) =>
        new PetDetailDto
        {
            AdoptionStatus = p.AdoptionStatus,
            Breed = p.Breed,
            DateOfBirth = p.DateOfBirth,
            Description = p.Description,
            Gender = p.Gender,
            Id = p.Id,
            Image = $"{AppConstants.BaseImagesUrl}/images/pets/{p.Image}",
            Name = p.Name,
            Price = p.Price
        };
}
