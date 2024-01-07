using System.Globalization;
using System.Net;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.VisualBasic.Logging;



namespace _2

{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string city = comboBox1.Text;

            await Task.Run(async () =>
            {
                StreamReader cities = new StreamReader("C:\\Users\\kolob\\OneDrive\\Рабочий стол\\sem3\\laba9\\city1.txt");
                double lat = 0; double lon = 0;
                string temp = cities.ReadToEnd();
                string[] city_strings = temp.Split('\n');
                foreach (string str in city_strings)
                {
                    string[] done_city_strings = str.Split(',');
                    if (done_city_strings[0] == city)
                    {
                        NumberFormatInfo provider = new NumberFormatInfo();
                        provider.NumberDecimalSeparator = ".";
                        lat = Convert.ToDouble(done_city_strings[1], provider);
                        lon = Convert.ToDouble(done_city_strings[2], provider);
                        break;
                    }
                }

                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=7014cad18f46440ad10609dba5cc3cb4&units=metric";
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                    WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                    Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text = (string)city;
                        textBox2.Text = (string)weatherResponse.Weather[0].Description;
                        textBox3.Text = $"{weatherResponse.Main.Temp}";
                    });
                }
            });
        }

        private void Form1_Load()
        {
            StreamReader cities = new StreamReader("C:\\Users\\kolob\\OneDrive\\Рабочий стол\\sem3\\laba9\\city1.txt");
            string temp = cities.ReadToEnd();
            string[] city_strings = temp.Split('\n');
            foreach (string str in city_strings)
            {
                string[] done_city_strings = str.Split(',');
                comboBox1.Items.Add(done_city_strings[0]);
            }

        }
        public struct City
        {
            public string Name { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }

            public City(string name, string lat, string lon)
            {
                this.Name = name;
                this.Latitude = lat;
                this.Longitude = lon;
            }
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

    }
}
