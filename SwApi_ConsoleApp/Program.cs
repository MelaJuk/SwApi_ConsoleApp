using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SwApi_ConsoleApp
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private const String requestUrlPeople = "https://swapi.dev/api/people/10/";


        static async Task Main()
        {
            try
            {
                // get people name and display it
                string responseBodyPeople = await client.GetStringAsync(requestUrlPeople);
                JObject jsonPeople = JObject.Parse(responseBodyPeople);
                Console.WriteLine(jsonPeople.GetValue("name"));

                // get vehicle'url 
                string requestUrlVehicle = jsonPeople.GetValue("vehicles").ToString();

                string[] charsToRemove = new string[] { "[", "]", " ", "\"" };
                foreach (var c in charsToRemove)
                {
                    requestUrlVehicle = requestUrlVehicle.Replace(c, string.Empty);
                }

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
    }
}
