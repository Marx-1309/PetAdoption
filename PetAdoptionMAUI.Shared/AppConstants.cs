namespace PetAdoptionMAUI.Shared;
public static class AppConstants
{
    public const string BaseApiUrl = "https://k56czln3-7055.inc1.devtunnels.ms";

    public const string BaseImagesUrl = BaseApiUrl;

    // Uncomment this if you are using localhost https api
    //public const string BaseImagesUrl = "https://github.com/Abhayprince/PetAdoptionMAUI/tree/master/PetAdoption.Api/wwwroot";

    public const string HubPattern = "/hubs/pet-hub";
    public const string HubFullUrl = BaseApiUrl + HubPattern;
}
