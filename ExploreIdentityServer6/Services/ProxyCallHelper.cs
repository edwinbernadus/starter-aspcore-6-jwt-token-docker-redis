using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Http;

namespace ExploreIdentityServer6.Services
{
    public enum ServerList
    {
        server_one,
        server_two,
    }

    public static class ProxyCallHelper<T>
    {
        public static async Task<ContentData<T>> Get(string inputUrl, ServerList serverName, HttpContext httpContext,bool isDocker)
        {
            var httpClient = new HttpClient();
            string currentAuthToken = ProxyCallHelper.GetCurrentAuthToken(httpContext);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", currentAuthToken);
            var host = ProxyCallHelper.GetServerName(serverName,isDocker);
            var url = $"{host}{inputUrl}";
            try
            {
                var response = await httpClient.GetAsync(url);
                var s = await response.Content.ReadAsStringAsync();
                // var s = await httpClient.GetStringAsync(url);
                // var output = JsonSerializer.Deserialize<T>(s);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                if (response.IsSuccessStatusCode)
                {
                    // var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                    var output = JsonSerializer.Deserialize<T>(s, options);

                    if (output != null)
                    {
                        var result = ContentData<T>.GenerateValid(output);
                        return result;
                    }
                    else
                    {
                        var result = ContentData<T>.GenerateErr("failed to parse");
                        return result;
                    }
                }
                else
                {
                    var output = JsonSerializer.Deserialize<ErrorInternal>(s, options);
                    if (output != null)
                    {
                        var result = ContentData<T>.GenerateErr(output.Message);
                        return result;
                    }
                    else
                    {
                        var result = ContentData<T>.GenerateErr("failed to parse - 2");
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                var result = ContentData<T>.GenerateErr(ex.Message);
                return result;
            }
        }
    }

    public static class ProxyCallHelper
    {
        public static async Task<string> Get(string inputUrl, ServerList serverName, HttpContext httpContext,bool isDocker)
        {
            var httpClient = new HttpClient();
            string currentAuthToken = GetCurrentAuthToken(httpContext);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", currentAuthToken);
            var host = GetServerName(serverName,isDocker);
            var url = $"{host}{inputUrl}";
            try
            {
                var s = await httpClient.GetStringAsync(url);
                return s;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return s;
            }
        }

        public static string GetCurrentAuthToken(HttpContext httpContext)
        {
            var output = httpContext.Request.Headers.Authorization;
            var output2 = output.ToString().Split(" ").Last();
            return output2;
        }

        public static string GetServerName(ServerList serverName,bool isDocker)
        {
            if (serverName == ServerList.server_one)
            {
                if (isDocker)
                {
                    return "http://logic_one:80";
                }
             
#if RELEASE
                return "https://greenfootballlogicone.azurewebsites.net";
#else
                return "https://localhost:5011";
#endif
            }
            else if (serverName == ServerList.server_two)
            {
#if RELEASE
                return "https://greenfootballlogictwo.azurewebsites.net";
#else
                return "https://localhost:5021";
#endif
            }
            else
            {
                return "";
            }
        }
    }
}