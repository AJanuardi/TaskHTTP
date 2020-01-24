using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace D1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
           var data = @"
            {""id"": 30,
            ""name"": ""Someone""
            }
            ";

            var getJsonResponse = await Fetcher.Get("https://httpbin.org/get");
            Console.WriteLine(getJsonResponse);
            var deleteJsonResponse = await Fetcher.Delete("https://httpbin.org/delete");
            Console.WriteLine(deleteJsonResponse);
            var postJsonResponse = await Fetcher.Post("https://httpbin.org/post", data);
            Console.WriteLine(postJsonResponse);
            var putJsonResponse = await Fetcher.Put("https://httpbin.org/put", data);
            Console.WriteLine(putJsonResponse);
            var patchJsonResponse = await Fetcher.Patch("https://httpbin.org/patch", data);
            Console.WriteLine(patchJsonResponse);
            

        }
    }
    public static class Fetcher
    {
        public static async Task<string> Post(string args, string data)
        {
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, args);
            var response1 = await client.PostAsync(args, content);
            return await response1.Content.ReadAsStringAsync();

        }
        public static async Task<string> Put(string args, string data)
        {
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, args);
            var response1 = await client.PutAsync(args, content);
            return await response1.Content.ReadAsStringAsync();
        }
         public static async Task<string> Patch(string args, string data)
        {
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, args);
            var response1 = await client.PatchAsync(args, content);
            return await response1.Content.ReadAsStringAsync();
        }
        public static async Task<string> Delete (string args)
        {
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, args);
        HttpResponseMessage response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> Get(string args)
        {
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, args);
        HttpResponseMessage response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
        }
    }
}
