using Refit;

namespace PetAdoptionMAUI.Mobile.ViewModels;
public partial class HomeViewModel : BaseViewModel
{

    private readonly IPetsApi _petsApi;
    private readonly CommonService _commonService;
    private readonly AuthService _authService;

    public HomeViewModel(IPetsApi petsApi, CommonService commonService, AuthService authService)
    {
        _petsApi = petsApi;
        _commonService = commonService;
        _authService = authService;
        _commonService.LoginStatusChanged += OnLoginStatusChanged;
        SetUserInfo();
    }

    private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo();
    private void SetUserInfo()
    {
        if (_authService.IsLoggedIn)
        {
            var userInfo = _authService.GetUser();
            UserName = userInfo.Name;
            _commonService.SetToken(userInfo.Token);
        }
        else
        {
            UserName = "Stranger";
        }
    }

    [ObservableProperty]
    private IEnumerable<PetListDto> _newlyAdded = Enumerable.Empty<PetListDto>();

    [ObservableProperty]
    private IEnumerable<PetListDto> _poplar = Enumerable.Empty<PetListDto>();

    [ObservableProperty]
    private IEnumerable<PetListDto> _random = Enumerable.Empty<PetListDto>();

    [ObservableProperty]
    private string _userName = "Stranger";

    private bool _isInitialized;
    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;

        IsBusy = true;
        try
        {
            await Task.Delay(100);
            var newlyAddedTask = _petsApi.GetNewlyAddedPetsAsync(5);
            var popularPetsTask = _petsApi.GetPopularPetsAsync(10);
            var randomPetsTask = _petsApi.GetRandomPetsAsync(6);

            NewlyAdded = (await newlyAddedTask).Data;
            Poplar = (await popularPetsTask).Data;
            Random = (await randomPetsTask).Data;

            _isInitialized = true;
        }
        catch (ApiException ex)
        {
            await ShowAlertAsync("Error", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
