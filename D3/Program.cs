using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Posts;
using Users;

namespace D3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient ();
            HttpRequestMessage requestPost = new HttpRequestMessage (HttpMethod.Get, "https://jsonplaceholder.typicode.com/posts");
            HttpResponseMessage responsePost = await client.SendAsync (requestPost);
            var jsonPost = await responsePost.Content.ReadAsStringAsync ();

            HttpRequestMessage requestUser = new HttpRequestMessage (HttpMethod.Get, "https://jsonplaceholder.typicode.com/users");
            HttpResponseMessage responseUser = await client.SendAsync (requestUser);
            var jsonUser = await responseUser.Content.ReadAsStringAsync ();

            var dataPost = JsonConvert.DeserializeObject<List<Post>>(jsonPost);
            var dataUser = JsonConvert.DeserializeObject<List<User>>(jsonUser);

            List<Merge> combine = new List<Merge>();
            
            Console.WriteLine(Merge());
            
            string Merge()
            {
                foreach (var post in dataPost)
                {
                    foreach (var user in dataUser)
                    {
                        if (post.UserId == user.Id)
                        {
                            Merge json = new Merge();
                            json.UserId = post.UserId;
                            json.Id = post.Id;
                            json.Title = post.Title;
                            json.Body = post.Body;
                            json.User = user;

                            combine.Add(json);
                        }
                    }
                }
                string jsonFile = JsonConvert.SerializeObject(combine, Formatting.Indented);
                return jsonFile;

            }
        }

        class Merge 
        {
        [JsonProperty ("userId")]
        public int UserId { get; set; }

        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("body")]
        public string Body { get; set; }

        [JsonProperty ("user")]
        public User User { get; set; }
        }
    }
}
