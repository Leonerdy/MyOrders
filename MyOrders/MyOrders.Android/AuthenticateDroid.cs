using System;
using Microsoft.WindowsAzure.MobileServices;
using MyOrders.Droid;
using System.Threading.Tasks;


[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace MyOrders.Droid
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, 
            MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}