using DemoD10BasicMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoD10BasicMVC.Models.Services
{
    public class HotelService : IHotelManager
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<List<Hotel>> GetAllHotels()
        {
            // REF: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
            // // GEt all the hotels from our 3rd party api

            // Set my destination
            var baseUrl = @"https://localhost:44330/api";
            string route = "hotels";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseUrl}/{route}");
            // converted to C# from JSON
            var result = await JsonSerializer.DeserializeAsync<List<Hotel>>(streamTask);

            return result;


            // Make my Get call

            //receive my response

            // deserialize my response

            // send it back
            throw new NotImplementedException();
        }

        public Task GetHotelByID()
        {
            throw new NotImplementedException();
        }
    }
}
