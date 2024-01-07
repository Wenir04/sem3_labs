using System.Net;
using System.Text.Json.Serialization;
using System.Security.Principal;
using Newtonsoft.Json;
using System.Net.Http.Json;


public class WeatherResponse
{
    public TemperatureInfo Main { get; set; }
    public CountryInfo Sys { get; set; }
    public string Name { get; set; }
    public DescriptionInfo[] Weather { get; set; }

    public void Print()
    {
        Console.Write("country: " + Sys.Country + ", ");
        Console.Write("name of place: " + Name + ", ");
        Console.Write("description: " + Weather[0].Description + ", ");
        Console.Write("temperature: " + Main.Temp + "\n");
    }
}

public class TemperatureInfo
{
    public float Temp { get; set; }
}

public class DescriptionInfo
{
    public string Description { get; set; }
}

public class CountryInfo
{
    public string Country { get; set; }
}
public struct Weather
{
    public string Country { get; set; }
    public string Name { get; set; }
    public double Temp { get; set; }
    public string Description { get; set; }

    public Weather(WeatherResponse weatherResponse)
    {
        this.Country = weatherResponse.Sys.Country;
        this.Name = weatherResponse.Name;
        this.Temp = weatherResponse.Main.Temp;
        this.Description = weatherResponse.Weather[0].Description;
    }

    public void Print()
    {
        Console.Write("country: " + Country + ", ");
        Console.Write("name of place: " + Name + ", ");
        Console.Write("description: " + Description + ", ");
        Console.Write("temperature: " + Temp + "\n");
    }
}

public class Program
{
    public static void Main()
    {

        string apiKey = "770c2c3365661b3c127f3a2657947aa4";

        List<Weather> weatherData = new List<Weather>();

        Random random = new Random();
        int count = 0;
        while (count < 50)
        {
            double latitude = random.NextDouble() * (90 - (-90)) + (-90);
            double longitude = random.NextDouble() * (180 - (-180)) + (-180);

            string url = "https://api.openweathermap.org/data/2.5/weather?lat=" + latitude.ToString() + "&" +
                         "lon=" + longitude.ToString() + "&exclude=minutely,hourly,daily,alerts&" +
                         "units=metric&appid=" + apiKey;

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                if ((!string.IsNullOrEmpty(weatherResponse.Name)) || (!string.IsNullOrEmpty(weatherResponse.Sys.Country)))
                {
                    Weather w = new Weather(weatherResponse);
                    w.Temp = Math.Round(w.Temp, 2);
                    weatherData.Add(w);
                    w.Print();
                    count++;
                }
            }
        }

        Console.WriteLine();

        var countryWithMaxTemp = weatherData.MaxBy(w => w.Temp).Country;
        Console.Write("страна с максимальной температурой: " + countryWithMaxTemp + " ");
        var maxTemp = weatherData.MaxBy(w => w.Temp).Temp;
        Console.Write("(" + maxTemp + " C)\n\n");

        var countryWithMinTemp = weatherData.MinBy(w => w.Temp).Country;
        Console.Write("страна с минимальной температурой: " + countryWithMinTemp);
        var minTemp = weatherData.MinBy(w => w.Temp).Temp;
        Console.Write("(" + minTemp + " C)\n\n");

        var averageTemp = weatherData.Average(w => w.Temp);
        Console.WriteLine("средняя температура в мире: " + averageTemp + "\n");
        
        var countryCount = weatherData.Select(w => w.Country).Distinct().Count();
        Console.WriteLine("количество стран в коллекции: " + countryCount + "\n");

        var firstMatch = weatherData.FirstOrDefault(w => w.Description == "clear sky" || w.Description ==
            "rain" || w.Description == "few clouds");
        Console.WriteLine($"Первая страна и местность подходящие под условие: " +
                          $"{firstMatch.Country}, {firstMatch.Name} with {firstMatch.Description}");

    }
}