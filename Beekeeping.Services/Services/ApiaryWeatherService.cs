namespace Beekeeping.Services.Services
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    using Data;
    using Models.Apiary;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ApiaryWeatherService : IApiaryWeatherService
    {
        private readonly HttpClient client;
        private readonly BeekeepingDbContext context;

        public ApiaryWeatherService(BeekeepingDbContext context)
        {
            client = new HttpClient();
            this.context = context;
        }

        public async Task<IEnumerable<ApiaryCoordinatesModel>> GetApiariesCoordinatesAsync(string userId)
        {
            return await context.Apiaries
                                .Where(a => a.OwnerId == userId)
                                .Select(a => new ApiaryCoordinatesModel 
                                {
                                    ApiaryName = a.Name,
                                    Latitude = a.Latitude, 
                                    Longitude = a.Longitude
                                })
                                .ToArrayAsync();
        }

        public async Task<ApiaryWeatherModel?> GetWeatherDataAsync(string query)
        {
            ApiaryWeatherModel? weatherData = null;

            try
            {
                var response = await client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<ApiaryWeatherModel>(content)!;
                }
            }
            catch
            {
                throw new InvalidOperationException();
            }

            return weatherData;
        }
    }
}

