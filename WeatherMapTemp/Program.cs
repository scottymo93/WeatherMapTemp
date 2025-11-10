
using Newtonsoft.Json.Linq;

var appsettingsText = File.ReadAllText("appsettings.json");
var apiKey = JObject.Parse(appsettingsText)["key"].ToString();

Console.WriteLine("Type in the zip code you would like to check the weather from, then press Enter.");

var zipCode = Console.ReadLine();

var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";
var client = new HttpClient();
var weatherResponseJson = client.GetStringAsync(url).Result;
var weatherTemp = JObject.Parse(weatherResponseJson)["main"]["temp"].ToString();
var weatherLocation = JObject.Parse(weatherResponseJson)["name"].ToString();
var weatherFeelsLike = JObject.Parse(weatherResponseJson)["main"]["feels_like"].ToString();


Console.WriteLine($"The weather in {weatherLocation} is {weatherTemp} degrees but it feels like {weatherFeelsLike} degrees.");

// I will make this look better, but at least it works!