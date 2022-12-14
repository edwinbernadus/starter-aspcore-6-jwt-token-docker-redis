using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Http;

namespace ExploreIdentityServer6.Services
{
    public static class HttpContextExtensions
    {
        public static async Task<ContentData<T>> GetRequest<T>(this HttpContext httpContext, string inputUrl,
            ServerList serverName,bool isDocker)
        {
            ContentData<T> output = await ProxyCallHelper<T>.Get(inputUrl, serverName, httpContext,isDocker);
            return output;
        }


        public static async Task<string> GetRequest(this HttpContext httpContext, string inputUrl,
            ServerList serverName,bool isDocker)
        {
            var output = await ProxyCallHelper.Get(inputUrl, serverName, httpContext,isDocker);
            return output;
        }
    }
}