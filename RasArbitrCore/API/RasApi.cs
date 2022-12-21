using RestSharp;

namespace RasArbitrCore.API
{
    public static class RasApi
    {
        public static PostResult? Post(PostRequest requestBody, RasWeb.Cookies cookies)
        {
            string url = "https://ras.arbitr.ru/";
            var client = new RestClient(url);
            string rasCookies = $"wasm={cookies.Wasm}; pr_fp={cookies.Pr_fp}";

            client.AddDefaultHeader("cookie", rasCookies);
            client.AddDefaultHeader("referer", url);
            client.AddDefaultHeader("x-requested-with", "XMLHttpRequest");

            var result = client.PostJson<PostRequest, PostResult>("Ras/Search", requestBody);

            return result;
        }
    }
}
