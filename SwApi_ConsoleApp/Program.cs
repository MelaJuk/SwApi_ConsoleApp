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

        static async Task Main()
        {
            try
            {
                // get json for Obi-Wan 
                string responseBodyPeople = await client.GetStringAsync(requestUrlPeople);

                // Deserialize() it
                People obiwan = JsonSerializer.Deserialize<People>(responseBodyPeople);

                // diplay the character name
                Console.WriteLine(obiwan.name);

                // get url and json for the vehicle 
                string vehicleUrl = obiwan.vehicles.GetValue(0).ToString();
                string responseVehicule = await client.GetStringAsync(vehicleUrl);

                // Deserialize() it
                Vehicle obiwanVehicle = JsonSerializer.Deserialize<Vehicle>(responseVehicule);

                // diplay the character name
                Console.WriteLine(obiwanVehicle.name);
               
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
