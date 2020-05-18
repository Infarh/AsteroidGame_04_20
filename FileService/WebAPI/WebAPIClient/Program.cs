using System;
using System.Net.Http;

namespace WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string address = "http://localhost:5000/api/weather";

            var client = new HttpClient();
            var response = client.GetAsync(address).Result;
            var data = response.Content.ReadAsAsync<DataValue[]>().Result;

            Console.ReadLine();
        }
    }

    struct DataValue
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
