using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using HtmlAgilityPack;

namespace CGVdata
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var options = new LaunchOptions { Headless = true };
            Console.WriteLine("Downloading Chromium");
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Console.WriteLine("Goes to CGV Now PLaying");

            using (var browser = await Puppeteer.LaunchAsync(options))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("https://www.cgv.id/en/movies/now_playing");
                var list = await page.QuerySelectorAllHandleAsync(".movie-list-body > ul >li > a").EvaluateFunctionAsync<string[]>("elements => elements.map(a => a.href)");
                Console.WriteLine("Movie List");
                for (int i =0; i<list.Length;i++)
                {
                    Console.WriteLine("==========================================================================================================");
                    Console.WriteLine("");
                    HtmlWeb web = new HtmlWeb();
                    var htmlDoc = web.Load(list[i]);
                    var nodes1 = htmlDoc.DocumentNode.SelectNodes("//div[@class='movie-info-title']");
                    foreach(var x in nodes1)
                    {
                        Console.WriteLine(x.InnerHtml.Trim());
                    }
                    var nodes2 = htmlDoc.DocumentNode.SelectNodes("//div[@class='trailer-btn-wrapper']/img");
                    foreach(var x in nodes2)
                    {
                        Console.WriteLine("Trailer : " + x.GetAttributeValue("onclick", string.Empty).Substring(11));
                    }
                    Console.WriteLine("PRODUCER : -");
                    var nodes3 = htmlDoc.DocumentNode.SelectNodes("//div[@class='movie-add-info left']/ ul / li");
                    foreach(var x in nodes3)
                    {
                        Console.WriteLine(x.InnerHtml.Trim());
                    }
                    var nodes4 = htmlDoc.DocumentNode.SelectNodes("//div[@class='movie-synopsis right']");
                    foreach(var x in nodes4)
                    {
                        Console.WriteLine("SINOPSIS : " + x.InnerText.Trim());
                    }
                    Console.WriteLine();
                   
                }
            }
        }
    }
}