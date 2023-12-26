using PetAdoptionMAUI.Shared.Dtos;

namespace PetAdoptionMAUI.Mobile.Services;
public class AuthService
{
    private readonly CommonService _commonService;
    private readonly IAuthApi _authApi;

    public AuthService(CommonService commonService, IAuthApi authApi)
    {
        _commonService = commonService;
        _authApi = authApi;
    }

    public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
    {
        ApiResponse<AuthResponseDto> apiResponse = null;
        try
        {
            if (model.IsNewUser)
            {
                apiResponse = await _authApi.RegisterAsync(new RegisterRequestDto
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                });
            }
            else
            {
                apiResponse = await _authApi.LoginAsync(new LoginRequestDto
                {
                    Email = model.Email,
                    Password = model.Password,
                });
            }
        }
        catch (Refit.ApiException ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");            
            return false;
        }

        if (!apiResponse.IsSuccess)
        {
            await App.Current.MainPage.DisplayAlert("Error", apiResponse.Message, "Ok");
            return false;
        }

        var user = new LoggedInUser(apiResponse.Data.UserId, apiResponse.Data.Name, apiResponse.Data.Token);
        SetUser(user);

        _commonService.SetToken(apiResponse.Data.Token);
        _commonService.ToggleLoginStatus();

        return true;
    }

    private void SetUser(LoggedInUser user) => Preferences.Default.Set(UIConstants.UserInfo, user.ToJson());

    public void Logout()
    {
        _commonService.SetToken(null);
        Preferences.Default.Remove(UIConstants.UserInfo);
        _commonService.ToggleLoginStatus();
    }

    public LoggedInUser GetUser()
    {
        var userJson = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
        return LoggedInUser.LoadFromJson(userJson);
    }

    public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
}
