using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using Generics;

namespace ConsoleApplication
{
    class ModuleConst
    {
        // SHOULD NOT BE PUBLIC
        static internal readonly string baseURI = "https://khodattenqua.azurewebsites.net/api/HttpTrigger";
    }
    class MessageEntity
    {
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }

    class MessageModel
    {
        private HttpClient httpModule;

        public MessageModel()
        {
            httpModule = new HttpClient();
            httpModule.DefaultRequestHeaders.Accept.Clear();
            httpModule.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpModule.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public async void saveOneMessage(string content)
        {
            string responseContent = "";

            try
            {
                HttpResponseMessage response = await httpModule.PostAsync(ModuleConst.baseURI,
                    JsonContent.Create(
                        new MessageEntity{ Content = content },
                        new MediaTypeWithQualityHeaderValue("application/json")
                    )
                );

                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException exception)
            {
                Console.WriteLine($"EXCEPTION: {exception.Message}");
            }

            
        }

        public async void saveManyMessages(IEnumerable<string> contents)
        {
            List<MessageEntity> responseContents = new();

            try
            {
                foreach (string content in contents)
                {
                    HttpResponseMessage response = await httpModule.PostAsync(ModuleConst.baseURI,
                        JsonContent.Create(
                            new MessageEntity{ Content = content },
                            new MediaTypeWithQualityHeaderValue("application/json")
                        )
                    );

                    string responseContent = await response.Content.ReadAsStringAsync();

                    responseContents.Add(new MessageEntity{ Content = responseContent });
                }
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"EXCEPTION: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("POST message successfully:");
                EnumerablePrinter<MessageEntity>.printEnumerableByComma(responseContents);
            }
        }
    }
}