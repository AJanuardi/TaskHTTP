using Newtonsoft.Json;

namespace Posts
{
    public class Post
    {
    [JsonProperty("userid")]
    public int UserId {get; set;}
    [JsonProperty("id")]
    public int Id {get; set;}
    [JsonProperty("title")]
    public string Title {get; set;}
    [JsonProperty("body")]
    public string Body {get; set;}
    }
}


