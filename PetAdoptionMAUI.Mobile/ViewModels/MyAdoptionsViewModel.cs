namespace PetAdoptionMAUI.Mobile.ViewModels
{
    public partial class MyAdoptionsViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly IUserApi _userApi;

        public MyAdoptionsViewModel(AuthService authService, IUserApi userApi)
        {
            _authService = authService;
            _userApi = userApi;
        }

        [ObservableProperty]
        private IEnumerable<PetListDto> _myAdoptions = Enumerable.Empty<PetListDto>();

        public async Task InitializeAsync()
        {
            if (!_authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in to see your adoptions");
                return;
            }

            try
            {
                IsBusy = true;
                await Task.Delay(100);
                var apiResponse = await _userApi.GetUserAdoptionsAsync();
                if (apiResponse.IsSuccess)
                {
                    MyAdoptions = apiResponse.Data;
                }
                else
                {
                    await ShowAlertAsync("Error", apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
