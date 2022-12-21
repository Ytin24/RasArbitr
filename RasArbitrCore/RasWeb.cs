using CefSharp;
using CefSharp.OffScreen;

namespace RasArbitrCore;

public class RasWeb
{
    public struct Cookies
    { 
        public string Wasm;
        public string Pr_fp;
    }
    public async Task<Cookies> GetCookies()
    {
        string? wasm, pr_fp;
        bool failed;

        using (var browser = new ChromiumWebBrowser())
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

                // Проверка на валидность //
                failed = wasm is null || pr_fp is null;
                if (failed)
                    await Task.Delay(5000);
                else
                    browser.Dispose();
            } while (failed);

            // Создайм структуру из полученных куки //
            var cookies = new Cookies
            { 
                Wasm = wasm,
                Pr_fp = pr_fp
            };

            return cookies;
        }
    }
}