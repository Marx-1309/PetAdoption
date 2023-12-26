namespace PetAdoptionMAUI.Shared;

public interface IPetHubClient
{
    Task PetIsBeingViewed(int petId);
    Task PetAdopted(int petId);
}
