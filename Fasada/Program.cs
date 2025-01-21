using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public interface IWeatherService
{
    Task<double> GetTemperatureForCityAsync(string cityName);
}

public class WeatherServiceFacade : IWeatherService
{
    private readonly HttpClient httpclient;
    private const string API_KEY = "fdcaeb02211673170385ed4768c0fe15";
    private const string WEATHER_BASE_URL = "https://api.openweathermap.org/data/2.5/weather";

    public WeatherServiceFacade(HttpClient httpClient)
    {
        httpclient = httpClient;
    }

    public async Task<double> GetTemperatureForCityAsync(string cityName)
    {
        try
        {
            var weatherUrl = $"{WEATHER_BASE_URL}?q={cityName}&appid={API_KEY}&units=metric";
            var weatherResponse = await httpclient.GetAsync(weatherUrl);
            weatherResponse.EnsureSuccessStatusCode();
            var weatherResponseBody = await weatherResponse.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(weatherResponseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (weatherData?.Main == null)
            {
                Console.WriteLine("Nie udało się pobrać danych pogodowych.");
                return double.NaN;
            }

            Console.WriteLine($"Temperatura dla {cityName}: {weatherData.Main.Temp}°C");
            return weatherData.Main.Temp;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Błąd sieci: {ex.Message}");
            return double.NaN;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Błąd deserializacji: {ex.Message}");
            return double.NaN;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
            return double.NaN;
        }
    }

    private class WeatherResponse
    {
        public MainData? Main
        {
            get;
            set;
        }
    }

    private class MainData
    {
        public double Temp
        {
            get;
            set;
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        using var httpClient = new HttpClient();
        IWeatherService weatherService = new WeatherServiceFacade(httpClient);

        while (true)
        {
            Console.Write("Podaj nazwę miasta (lub 'exit' aby zakończyć): ");
            string cityName = Console.ReadLine();

            if (cityName.ToLower() == "exit")
            {
                return;
            }

            double temperature = await weatherService.GetTemperatureForCityAsync(cityName);
            if (!double.IsNaN(temperature))
            {
                Console.WriteLine($"Aktualna temperatura w mieście {cityName}: {temperature}°C");
            }
            else
            {
                Console.WriteLine("Nie udało się pobrać temperatury.");
            }
        }
    }
}


