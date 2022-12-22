using RestSharp;
using Newtonsoft.Json;
namespace RasArbitrCore.API
{
    public static class RasApi
    {
        public static async Task<PostResult?> Post(PostRequest requestBody, RasWeb.Cookies cookies)
        {
            string url = "https://ras.arbitr.ru/";
            var client = new RestClient(url);
            var request = new RestRequest("Ras/Search");
            string rasCookies = $"wasm={cookies.Wasm}; pr_fp={cookies.Pr_fp}";

            client.AddDefaultHeader("cookie", rasCookies);
            client.AddDefaultHeader("referer", url);
            client.AddDefaultHeader("x-requested-with", "XMLHttpRequest");
            request.AddJsonBody(requestBody);

            var result = await client.PostAsync(request);

            return JsonConvert.DeserializeObject<PostResult>(result.Content);

        }
    }
}
