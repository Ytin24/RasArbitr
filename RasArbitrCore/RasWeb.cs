using CefSharp;
using CefSharp.OffScreen;

namespace RasArbitrCore;

public static class RasWeb
{
    public class Cookies
    {
        public DateTime Expired; //надо реализовать таймер обновления коков
        public string Wasm;
        public string Pr_fp;
    }
    
    public static async Task<Cookies> GetCookies()
    {
        string? wasm = null, 
                pr_fp = null;
        DateTime ExpiredDate;
        string url = "https://ras.arbitr.ru/";
        bool failed = false;

        using (var browser = new ChromiumWebBrowser(url))
        {
            var initialLoadResponse = await browser.WaitForInitialLoadAsync();

            if (!initialLoadResponse.Success)
                throw new Exception(string.Format("Ошибка загрузки страницы с кодом:{0}, HttpStatusCode:{1}", initialLoadResponse.ErrorCode, initialLoadResponse.HttpStatusCode));

            do
            {
                // Программно нажимаем на кнопку поиска на сайте, чтобы сгенерировались куки для доступа //
                browser.ExecuteScriptAsync("document.getElementById('b-form-submit').click()");
                await Task.Delay(3000);

                var kadCookies = await browser.GetCookieManager().VisitAllCookiesAsync();

                // Проверка на валидность //
                try
                {
                    wasm = kadCookies.First(c => c.Name == "wasm").Value;
                    pr_fp = kadCookies.First(c => c.Name == "pr_fp").Value;
                    ExpiredDate = (DateTime)kadCookies.First(c => c.Name == "wasm").Expires;

                }
                catch
                {
                    failed = true;
                    ExpiredDate = DateTime.MinValue; // Костыль (9(
                    await Task.Delay(5000);
                    continue;
                }

                browser.Dispose();
            } while (failed);

            // Создаём класс из полученных куки //
            var cookies = new Cookies
            {
                Wasm = wasm,
                Pr_fp = pr_fp,
                Expired = ExpiredDate,
            };

            return cookies;
        }
    }
}