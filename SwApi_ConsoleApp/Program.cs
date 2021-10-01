using System;
using System.Net.Http;
using System.Threading.Tasks;
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
                var obiwan = GetCharacter().Result;
                var obiwanVehicle = GetVehicle(obiwan).Result;

                string neededInfo = $"Mon nom est {obiwan.name} et je conduis le fake {obiwanVehicle.name}";

                Console.WriteLine(neededInfo);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task<People> GetCharacter()
        {

            // get json for Obi-Wan 
            string responseBodyPeople = await client.GetStringAsync(requestUrlPeople);

            // Deserialize() it
            People obiwan = JsonSerializer.Deserialize<People>(responseBodyPeople);

            return obiwan; 
        }

        static async Task<Vehicle> GetVehicle(People people)
        {

            // get url and json for the vehicle 
            var url = people.vehicles.GetValue(0).ToString();
            //string vehicleUrl = await obiwan.vehicles.GetValue(0).ToString();
            string responseVehicule = await client.GetStringAsync(url);

            // Deserialize() it
            Vehicle obiwanVehicle = JsonSerializer.Deserialize<Vehicle>(responseVehicule);

            return obiwanVehicle;

        }
    }
}
