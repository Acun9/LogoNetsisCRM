using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientExample
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://srv1:8491/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var authResponse = await client.PostAsJsonAsync("api/authenticate", new { username = "Murat Acun", password = "Murat-378516" });
                    if (authResponse.IsSuccessStatusCode)
                    {
                        var token = await authResponse.Content.ReadAsStringAsync();
                        Console.WriteLine("Token: " + token);
                    }
                    else
                    {
                        Console.WriteLine("Authentication failed with status code: " + authResponse.StatusCode);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Request error: " + e.Message);
                }
            }
        }
    }
}
