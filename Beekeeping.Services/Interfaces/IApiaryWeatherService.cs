namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Apiary;

    public interface IApiaryWeatherService
    {
        Task<ApiaryWeatherModel> GetWeatherDataAsync(string query);

        Task<IEnumerable<ApiaryCoordinatesModel>> GetApiariesCoordinatesAsync(string userId);
    }
}