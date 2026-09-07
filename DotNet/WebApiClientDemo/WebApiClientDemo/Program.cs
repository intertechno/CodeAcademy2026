using System.Text.Json;
using WebApiClientDemo;

HttpClient client = new();

// set the HTTP client timeout to 5 seconds
Console.WriteLine("Setting HTTP client timeout to 5 seconds...");
client.Timeout = TimeSpan.FromSeconds(5);

// call the endpoint using a regular GET request
string url = "https://webapitest.intertechno.org/weatherforecast";
string json = await client.GetStringAsync(url);

// deserialize the JSON response into a list of WeatherForecast objects
List<WeatherForecast> forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(json)!;
foreach (WeatherForecast forecast in forecasts)
{
    Console.WriteLine($"Date: {forecast.date}, TemperatureC: {forecast.temperatureC}, Summary: {forecast.summary}");
}

Console.WriteLine("-----------------");

// call the "slow" endpoint using a regular GET request
url = "https://webapitest.intertechno.org/api/slow?seconds=10";
string slowJson = await client.GetStringAsync(url);
