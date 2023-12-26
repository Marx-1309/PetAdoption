using Microsoft.AspNetCore.SignalR.Client;
using PetAdoptionMAUI.Shared;

namespace PetAdoptionMAUI.Mobile.ViewModels;

[QueryProperty(nameof(PetId), nameof(PetId))]
public partial class DetailsViewModel : BaseViewModel, IAsyncDisposable
{
    private readonly IPetsApi _petsApi;
    private readonly AuthService _authService;
    private readonly IUserApi _userApi;
    private HubConnection? _hubConnection;

    public DetailsViewModel(IPetsApi petsApi, AuthService authService, IUserApi userApi)
    {
        _petsApi = petsApi;
        _authService = authService;
        _userApi = userApi;
    }

    [ObservableProperty]
    private int _petId;

    [ObservableProperty]
    private Pet _petDetail = new();

    async partial void OnPetIdChanging(int petId)
    {
        IsBusy = true;
        try
        {
            await Task.Delay(100);

            await ConfigureSignalRHubConnectionAsync(petId);

            var apiResponse = _authService.IsLoggedIn
                              ? await _userApi.GetPetDetailsAsync(petId)
                              : await _petsApi.GetPetDetailsAsync(petId);

            if (apiResponse.IsSuccess)
            {
                var petDto = apiResponse.Data;
                PetDetail = new Pet
                {
                    AdoptionStatus = petDto.AdoptionStatus,
                    Age = petDto.Age,
                    Breed = petDto.Breed,
                    Description = petDto.Description,
                    GenderDisplay = petDto.GenderDisplay,
                    GenderImage = petDto.GenderImage,
                    Id = petDto.Id,
                    Image = petDto.Image,
                    IsFavorite = petDto.IsFavorite,
                    Name = petDto.Name,
                    Price = petDto.Price
                };
            }
            else
            {
                await ShowAlertAsync("Error in fetching pet details", apiResponse.Message);
            }
        }
        catch (Exception ex)
        {
            await ShowAlertAsync("Error in fetching pet details", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task ConfigureSignalRHubConnectionAsync(int currentPetId)
    {
        try { 
            _hubConnection = new HubConnectionBuilder()
                                    .WithUrl(AppConstants.HubFullUrl)
                                    .Build();

            _hubConnection.On<int>(nameof(IPetHubClient.PetIsBeingViewed), async petId =>
            {
                if(currentPetId == petId)
                {
                    await App.Current.Dispatcher.DispatchAsync(() => ShowToastAsync("Someone else is also viewing this pet"));                    
                }
            });

            _hubConnection.On<int>(nameof(IPetHubClient.PetAdopted), async petId =>
            {
                if (currentPetId == petId)
                {
                    PetDetail.AdoptionStatus = AdoptionStatus.Adopted;
                    await App.Current.Dispatcher.DispatchAsync(() => ShowToastAsync("Someone adopted this pet. You wont be able to adopt this pet now"));
                }
            });

            await _hubConnection.StartAsync();
            await _hubConnection.SendAsync(nameof(IPetHubServer.ViewingThisPet), currentPetId);
        }
        catch(Exception ex)
        {
            // Eat out this exception
            // This is not an essential feature for this app
            // If there is some issue with this signalr connection, we can skip it
            // as the app will work fine without signalr as well
        }
    }

    [RelayCommand]
    private async Task GoBack() => await GoToAsync("..");

    [RelayCommand]
    private async Task ToggleFavorite()
    {
        if (!_authService.IsLoggedIn)
        {
            await ShowToastAsync("You need to be logged in to mark this pet as favorite");
            return;
        }

        PetDetail.IsFavorite = !PetDetail.IsFavorite;

        try
        {
            IsBusy = true;
            await _userApi.ToggleFavoritesAsync(PetId);
            IsBusy = false;
        }
        catch (Exception ex)
        {
            IsBusy = false;

            //Revert 
            PetDetail.IsFavorite = !PetDetail.IsFavorite;

            await ShowAlertAsync("Error in toggling favorite status", ex.Message);
        }
    }

    [RelayCommand]
    private async Task AdoptNowAsync()
    {
        if (!_authService.IsLoggedIn)
        {
            if(await ShowConfirmAsync("Not Logged in", "You need to be logged in to adopt a pet." + Environment.NewLine + "Do you want to go to login page?", "Yes", "No"))
            {
                await GoToAsync($"//{nameof(LoginRegisterPage)}");
            }            
            return;
        }

        IsBusy = true;
        try
        {
            var apiResponse = await _userApi.AdoptPetAsync(PetId);
            if (apiResponse.IsSuccess)
            {
                PetDetail.AdoptionStatus = AdoptionStatus.Adopted;
                if(_hubConnection is not null)
                {
                    try
                    {
                        await _hubConnection.SendAsync(nameof(IPetHubServer.PetAdopted), PetId);
                    }
                    catch (Exception)
                    {
                    }
                }
                await GoToAsync(nameof(AdoptionSuccessPage));
            }
            else
            {
                await ShowAlertAsync("Error in adoption", apiResponse.Message);
            }
            IsBusy = false;
        }
        catch (Exception ex)
        {
            await ShowAlertAsync("Error in adoption", ex.Message);
            IsBusy = false;
        }
    }

    public async ValueTask DisposeAsync() => await StopHubConnection();
    public async Task StopHubConnection()
    {
        if (_hubConnection is not null)
        {
            try
            {
                await _hubConnection.SendAsync(nameof(IPetHubServer.ReleaseViewingThisPet), PetId);
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                // Skip this exception
            }
        }
    }
}
