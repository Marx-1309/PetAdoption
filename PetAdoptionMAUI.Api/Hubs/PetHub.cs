using Microsoft.AspNetCore.SignalR;
using PetAdoptionMAUI.Shared;

namespace PetAdoptionMAUI.Api.Hubs;

public class PetHub : Hub<IPetHubClient>, IPetHubServer
{
    private static readonly IDictionary<int, int> _petsBeingViewed = new Dictionary<int, int>();

    public async Task PetAdopted(int petId)
    {
        await Clients.Others.PetAdopted(petId);
        if(_petsBeingViewed.ContainsKey(petId))
            _petsBeingViewed.Remove(petId);
    }

    public Task ReleaseViewingThisPet(int petId)
    {
        if (_petsBeingViewed.TryGetValue(petId, out int currentlyViewing))
        {
            currentlyViewing--;
        }
        if(currentlyViewing <= 0)
            _petsBeingViewed.Remove(petId);
        else
            _petsBeingViewed[petId] = currentlyViewing;

        return Task.CompletedTask;
    }

    public async Task ViewingThisPet(int petId)
    {
        if(!_petsBeingViewed.TryGetValue(petId, out int currentlyViewing))
        {
            currentlyViewing = 0;
        }
        else
        {
            // This pet already exists in he disctionary
            // i.e. there are users viewwig this pet already
            // Notify this current user that you are not the only one viewing this pet
            await Clients.Caller.PetIsBeingViewed(petId);
        }

        _petsBeingViewed[petId] = currentlyViewing++;

        // Notify other users
        await Clients.Others.PetIsBeingViewed(petId);
    }
}

