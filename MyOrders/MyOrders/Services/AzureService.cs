using Microsoft.WindowsAzure.MobileServices;
using MyOrders.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace MyOrders.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://speedservicesocial.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

            
        

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Não conseguimos efetuar o seu login, tente novamente", "Ok");
                });
                return null;
            }
            return user;
        }
    }
}
