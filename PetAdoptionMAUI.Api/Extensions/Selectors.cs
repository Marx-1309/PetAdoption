using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared;
using PetAdoptionMAUI.Shared.Dtos;
using System.Linq.Expressions;

namespace PetAdoptionMAUI.Api.Extensions;

public static class Selectors
{
    public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
        p => new PetListDto
        {
            Breed = p.Breed,
            Id = p.Id,
            Image = $"{AppConstants.BaseImagesUrl}/images/pets/{p.Image}",
            Name = p.Name,
            Price = p.Price
        };
}
