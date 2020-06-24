using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Device.Location;
using System;
using IpData;
using IPGeolocation;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebApplication1.Utils
{
    public class LocationConverter
    {

        private readonly WebServiceClient _maxMindClient;

        [HttpGet]
        public async Task<Location> Get(string ip)
        {
            Location location = new Location();
            using (var reader = new DatabaseReader("./Utils/GeoLite2-City.mmdb"))
            {
                // Replace "City" with the appropriate method for your database, e.g.,
                // "Country".
                var city = reader.City(ip);
                if (city.Location.Latitude != null && city.Location.Longitude != null)
                {
                    location = new Location((double)city.Location.Latitude, (double)city.Location.Longitude);
                    Console.Out.WriteLine(city.City);
                }
                

            }

            return location;
        }

    }
}