using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace D4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<List<string>> done = new List<List<string>>();
            HtmlWeb web = new HtmlWeb();
            var htmldoc = web.Load("http://kompas.com");
            var nodes = htmldoc.DocumentNode.SelectNodes("//a[@class='headline__thumb__link']");
            foreach (var x in nodes)
            {
                var link = x.GetAttributeValue("href", string.Empty);
                var title = x.InnerText.Trim();
                done.Add(new List<string>{title, link});
            }
            
            
            foreach (var x in done)
            {
                Console.WriteLine("============================================================================================================================");
                Console.WriteLine(x[0]);
                Console.WriteLine(x[1]);
                Console.WriteLine("============================================================================================================================");
            }
            
        }
    }
}
