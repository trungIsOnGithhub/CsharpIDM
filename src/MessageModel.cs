using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication
{
    class MessageEntity
    {
        public string content { get; set; }
    }
    class MessageModel
    {
        static readonly HttpClient httpModule = new HttpClient();

        static readonly string URI = "https://khodattenqua.azurewebsites.net/api/HttpTrigger1";

        static void config()
        {
            httpModule.DefaultRequestHeaders.Accept.Clear();
            httpModule.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpModule.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public static async void save(string _content)
        {
            config();

            string responseContent = "";

            try
            {
                HttpResponseMessage response = await httpModule.PostAsync(URI,
                    JsonContent.Create(
                        new MessageEntity{ content = _content },
                        new MediaTypeWithQualityHeaderValue("application/json")
                    )
                );

                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException exception)
            {
                Console.WriteLine($"EXCEPTION: {exception.Message}");
            }

            // return responseContent;
        }
    }
}