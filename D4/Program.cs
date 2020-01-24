using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace D4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage1 = new HttpRequestMessage(HttpMethod.Get, "https://api.themoviedb.org/3/search/movie?api_key=1ee9e1a1e844160cd69d6c953eb09282&language=en-US&query=Indonesia&page=1&include_adult=false&region=ID");
            HttpResponseMessage responseMessage1 = await client.SendAsync(requestMessage1);
            var Indonesia = await responseMessage1.Content.ReadAsStringAsync();
            var dataInd = JsonConvert.DeserializeObject<Info>(Indonesia);
            var result1 = from l in dataInd.Results select l.OriginalTitle;
            Console.WriteLine("=====================================List Film Indonesia=========================================");
            foreach (var x in result1)
            {
                Console.WriteLine("Judul Film: "+x);
            }
            HttpRequestMessage requestMessage2 = new HttpRequestMessage(HttpMethod.Get, "https://api.themoviedb.org/3/discover/movie?api_key=1ee9e1a1e844160cd69d6c953eb09282&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast=6384");
            HttpResponseMessage responseMessage2 = await client.SendAsync(requestMessage2);
            var Keanu = await responseMessage2.Content.ReadAsStringAsync();
            var dataKeanu = JsonConvert.DeserializeObject<Info>(Keanu);
            var result2 = from l in dataKeanu.Results select l.OriginalTitle;
            Console.WriteLine("==================================List Film Keanu Reeves==========================================");
            foreach (var x in result2)
            {
                Console.WriteLine("Judul Film: "+x);
            }
            HttpRequestMessage requestMessage3 = new HttpRequestMessage(HttpMethod.Get, "https://api.themoviedb.org/3/discover/movie?api_key=1ee9e1a1e844160cd69d6c953eb09282&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast=3223%2C%201136406");
            HttpResponseMessage responseMessage3 = await client.SendAsync(requestMessage3);
            var Bersama = await responseMessage3.Content.ReadAsStringAsync();
            var dataBersama = JsonConvert.DeserializeObject<Info>(Bersama);
            var result3 = from l in dataKeanu.Results select l.OriginalTitle;
            Console.WriteLine("=======================List Film Downey dan Tom Holland bersama====================================");
            foreach (var x in result3)
            {
                Console.WriteLine("Judul Film: "+x);
            }
            HttpRequestMessage requestMessage4 = new HttpRequestMessage(HttpMethod.Get, " https://api.themoviedb.org/3/discover/movie?api_key=1ee9e1a1e844160cd69d6c953eb09282&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&release_date.gte=2016&vote_average.gte=7.5");
            HttpResponseMessage responseMessage4 = await client.SendAsync(requestMessage4);
            var Populer = await responseMessage4.Content.ReadAsStringAsync();
            var dataPopuler = JsonConvert.DeserializeObject<Info>(Populer);
            var result4 = from l in dataKeanu.Results select l.OriginalTitle;
            Console.WriteLine("=================================List Film Terbaik 2016 keatas=====================================");
            foreach (var x in result4)
            {
                Console.WriteLine("Judul Film: "+x);
            }
        }
    }
    class Info
    {
        [JsonProperty("page")]
        public int Page {get; set;}
        [JsonProperty("total_results")]
        public int TotalResults {get; set;}
        [JsonProperty("total_pages")]
        public int TotalPages {get; set;}
        [JsonProperty("results")]
        public List<Results> Results {get; set;}
    }
    class Results
    {
        [JsonProperty("popularity")]
        public double Popularity {get; set;}
        [JsonProperty("id")]
        public int Id {get; set;}
        [JsonProperty("video")]
        public bool Video {get; set;}
        [JsonProperty("vote_count")]
        public int VoteCount {get; set;}
        [JsonProperty("vote_average")]
        public double VoteAverage {get; set;}
        [JsonProperty("title")]
        public string Title {get; set;}
        [JsonProperty("release_date")]
        public string ReleaseDate {get; set;}
        [JsonProperty("original_language")]
        public string OriginalLanguage {get; set;}
        [JsonProperty("original_title")]
        public string OriginalTitle {get; set;}
        [JsonProperty("genre_ids")]
        public string[] GenreIds {get; set;}
        [JsonProperty("backdrop_path")]
        public string BackdropPath {get; set;}
        [JsonProperty("adult")]
        public bool Adult {get; set;}
        [JsonProperty("overview")]
        public string Overview {get; set;}
        [JsonProperty("poster_path")]
        public string PosterPath {get; set;}
    }
}
