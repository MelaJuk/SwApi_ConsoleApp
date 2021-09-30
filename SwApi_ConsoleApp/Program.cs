using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace SwApi_ConsoleApp
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        const String requestUrlPeople = "https://swapi.dev/api/people/10/";
        static string jsonString;


        static async Task Main()
        {
            
            try
            {
                //Serialize();
                // get json for Obi-Wan and serialize it 
                string responseBodyPeople = await client.GetStringAsync(requestUrlPeople);
                //var options = new JsonSerializerOptions { WriteIndented = true };
                //jsonString = JsonSerializer.Serialize(responseBodyPeople);
                //Console.WriteLine(jsonString);

                // get vehicle'url 
                string requestUrlVehicle = jsonPeople.GetValue("vehicles").ToString();

                // Deserialize();
                People obiwan = JsonSerializer.Deserialize<People>(responseBodyPeople);
                Console.WriteLine(obiwan);



                // display name of the vehicule 
                string responseBodyVehicles = await client.GetStringAsync(requestUrlVehicle);
                JObject jsonVehicles = JObject.Parse(responseBodyVehicles);
                Console.WriteLine(jsonVehicles.GetValue("name"));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        //static async Task Serialize()
        //{
        //    // get json for Obi-Wan
        //    string responseBodyPeople = await client.GetStringAsync(requestUrlPeople);
        //    jsonString = JsonConvert.SerializeObject(responseBodyPeople);
           
        //}

        //static async Task Deserialize()
        //{
        //    var obiwan = JsonConvert.DeserializeObject<People>(jsonString);
        //    Console.WriteLine(obiwan.ToString());
        //}
    }
}
