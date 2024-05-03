namespace Production.Services.Context
{
    public interface IForecastService
    {
        Task<double> GenerateForecast();
    }
}
