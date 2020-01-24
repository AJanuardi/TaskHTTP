using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace D2
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://mul14.github.io/data/employees.json");
            HttpResponseMessage response = await client.SendAsync(request);

            var data = await response.Content.ReadAsStringAsync();

            var ObjekList = JsonConvert.DeserializeObject<List<employee>>(data);
            
            Console.WriteLine("=============================");
            Console.WriteLine("Gaji diatas Rp 15.000.000: ");
            var result1 = ObjekList.Where(i => (i.Salary) > 15000000);
            foreach(var x in result1)
            {
                Console.WriteLine(x.Username);
            }

            Console.WriteLine("=============================");
            Console.WriteLine("Tempat tinggal di Jakarta: ");
            var results = from l in ObjekList from x in l.Addresses where (x.City).Contains("Jakarta") select (l.Username);
            var result2 = results.Distinct();
            foreach(var x in result2)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("=============================");
            Console.WriteLine("Lahir bulan Maret: ");
            var result3 = ObjekList.Where(i => (i.Bhirtday).Month == 3);
            foreach(var x in result3)
            {
                Console.WriteLine(x.Username);
            }

            Console.WriteLine("=============================");
            Console.WriteLine("Posisi RnD: ");
            var result4 = ObjekList.Where(i => (i.Department.Name).Contains("Research and development"));
            foreach(var x in result4)
            {
                Console.WriteLine(x.Username);
            }
            Console.WriteLine("=============================");
            Console.WriteLine("Absen October 2019: ");
            var result5 = from l in ObjekList from k in l.PresenceList where (k.Contains("2019-10")) select l.Username;
            Dictionary<string, int> october = result5.GroupBy(october=>october).ToDictionary(i => i.Key, i => i.Count());
            foreach (var x in october)
            {
                Console.WriteLine(x.Key + " :" + x.Value);
            }
        }

    }
    public class employee
    {
        [JsonProperty("id")]
        public int ID {get; set;}
        [JsonProperty("avatar")]
        public string AvatarUrl {get; set;}
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string Lastname {get; set;}
        [JsonProperty("email")]
        public string Email {get; set;}
        [JsonProperty("username")]
        public string Username {get; set;}
        [JsonProperty("bhirtday")]
        public DateTime Bhirtday {get; set;}
        [JsonProperty("salary")]
        public int Salary {get; set;}
        [JsonProperty("addresses")]
        public List<Addresses> Addresses {get; set;} = new List<Addresses>();
        [JsonProperty("phones")]
        public List<Phones> Phones {get; set;} = new List<Phones>();
        [JsonProperty("department")]
        public Department Department {get; set;}
        [JsonProperty("position")]
        public Position Position {get; set;}
        [JsonProperty("presence_list")]
        public string[] PresenceList {get; set;}
    }
    public class Addresses
    {
        [JsonProperty("label")]
        public string label {get; set;}
        [JsonProperty("address")]
        public string Address {get; set;}
        [JsonProperty("city")]
        public string City { get; set; }
    }
    public class Phones
    {
        [JsonProperty("label")]
        public string Label {get; set;}
        [JsonProperty("phone")]
        public int Phone {get; set;}
    }
    public class Department
    {
        [JsonProperty("name")]
        public string Name {get; set;}
    }
    public class Position
    {
        [JsonProperty("name")]
        public string Name {get; set;}
    }
}
