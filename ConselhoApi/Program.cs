using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsumerAdviceApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://api.adviceslip.com/advice";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazendo um GET na API
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lendo a resposta
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Analisando a resposta
                    JObject json = JObject.Parse(responseBody);
                    string advice = json["slip"]["advice"].ToString();

                    Console.WriteLine("\nConselho de Hoje: \n" + advice);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }
            }
        }
    }
}
