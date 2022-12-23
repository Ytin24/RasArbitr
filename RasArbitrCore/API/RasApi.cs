using RestSharp;
using Newtonsoft.Json;
using CefSharp.DevTools.Network;
using RasArbitrCore.Model;
using System.Diagnostics;

namespace RasArbitrCore.API
{
    public static class RasApi
    {
        public static async Task<PostResult?> Post(string Json, RasWeb.Cookies cookies)
        {
            string url = "https://ras.arbitr.ru/";
            var client = new RestClient(url);
            var request = new RestRequest("Ras/Search");
            string rasCookies = $"wasm={cookies.Wasm}; pr_fp={cookies.Pr_fp}";

            client.AddDefaultHeader("cookie", rasCookies);
            client.AddDefaultHeader("referer", url);
            client.AddDefaultHeader("x-requested-with", "XMLHttpRequest");
            request.AddJsonBody(Json);

            var result = await client.PostAsync(request);

            return JsonConvert.DeserializeObject<PostResult>(result.Content);

        }
        //public static async Task<string> DowloadFile(ItemAnswerView item) {
        //    var path = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), $"Downloads\\KolhoZ_{item.File}");
        //    var client = new RestClient(item.FileName);
        //    var result = client.Get(new());
        //    //var result = await client.DownloadStreamAsync(new RestRequest());
        //    //var file = File.Create(path);
        //    //await result.CopyToAsync(file);
        //    return path;
            
        //}
    }
}
