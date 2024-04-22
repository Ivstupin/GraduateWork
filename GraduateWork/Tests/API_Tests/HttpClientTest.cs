using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GraduateWork.Tests.API_Tests
{
    public class HttpClientTest
    {
        [Test]
        public async Task ClientTest()
        {
            const string baseUrl = "https://ivst.testmo.net/";

            using (HttpClient client = new HttpClient())
            {
                try 
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode) 
                    { 
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                    else 
                    {
                        Console.WriteLine($"Ошибка: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e) 
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
