using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PetAdoptionMAUI.Shared;
using Refit;

namespace PetAdoptionMAUI.Mobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        RegisterAppDependencies(builder.Services);
        ConfigureRefit(builder.Services);

        return builder.Build();
    }

    static void RegisterAppDependencies(IServiceCollection services)
    {
        services.AddSingleton<CommonService>();

        services.AddTransient<AuthService>();

        services.AddTransient<LoginRegisterViewModel>()
                .AddTransient<LoginRegisterPage>();

        services.AddSingleton<HomeViewModel>()
                .AddSingleton<HomePage>();

        services.AddSingleton<AllPetsViewModel>()
                .AddTransient<AllPetsPage>();

        services.AddTransientWithShellRoute<DetailsPage, DetailsViewModel>(nameof(DetailsPage));

        services.AddTransient<ProfileViewModel>()
                .AddTransient<ProfilePage>();

        services.AddTransient<FavoritesViewModel>()
                .AddTransient<FavoritesPage>();

        services.AddTransientWithShellRoute<AdoptionsPage, MyAdoptionsViewModel>(nameof(AdoptionsPage));
    }

    static void ConfigureRefit(IServiceCollection services)
    {
        services.AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IPetsApi>()
            .ConfigureHttpClient(SetHttpClient);
                
        services.AddRefitClient<IUserApi>(sp =>
            {
                var commonService = sp.GetRequiredService<CommonService>();
                return new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(commonService.Token ?? string.Empty)
                };
            })
            .ConfigureHttpClient(SetHttpClient);

        static void SetHttpClient(HttpClient httpClient) =>
            httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl);
    }
}
