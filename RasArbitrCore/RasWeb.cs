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
        string? wasm, pr_fp;
        DateTime ExpiredDate;
        string url = "https://ras.arbitr.ru/";
        bool failed;

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

                wasm = kadCookies.First(c => c.Name == "wasm").Value;
                pr_fp = kadCookies.First(c => c.Name == "pr_fp").Value;
                ExpiredDate = (DateTime)kadCookies.First(c => c.Name == "wasm").Expires;

                // Проверка на валидность //
                failed = wasm is null || pr_fp is null;
                if (failed)
                    await Task.Delay(5000);
                else
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