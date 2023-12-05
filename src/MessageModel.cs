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

    class Cocktail
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strGlass { get; set; }
        public string strCategory { get; set; }
        public string strAlcoholic { get; set; }
    }
    class CocktailList {
        public string[] drinks { get; set; }
    }
    class CocktailModel
    {
        public string VersionString { get; set; }

        static private readonly string baseURI = "https://www.thecocktaildb.com/api/json";

        static readonly HttpClient httpModule = new HttpClient();
        static void config()
        {
            httpModule.DefaultRequestHeaders.Accept.Clear();
            httpModule.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpModule.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public CocktailModel()
        {}

        public async void getCocktailByFirstLetter(char firstLetter)
        {
            config();

            string path = "search.php",
                    query = $"?f={firstLetter}";

            string specificURI = baseURI + "/" + VersionString + "/" + KeyVault.getKeyFor(baseURI)  + "/" + path + query;

            Console.WriteLine($"===> {specificURI}");

            string responseContent = "";

            try
            {
                HttpResponseMessage response = await httpModule.GetAsync(specificURI);

                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch(Exception exception)
            {
                Console.WriteLine($"EXCEPTION: {exception.Message}");
                return;
            }

            Console.WriteLine($"RESPONSE: |{responseContent.GetType()}|");

            IEnumerable<Cocktail> cocktailList = getCocktaiListFromJson(responseContent);

            cocktailList.Where(cocktail => cocktail.strAlcoholic == "alcoholic")
                        .ToList().ForEach(cocktail => Console.WriteLine(cocktail.strDrink));
            // Console.WriteLine($"LENGTH : {cocktailList.drinks.Length}");
        }

        public static IEnumerable<Cocktail> getCocktaiListFromJson(string json)
        {
            JObject jsonObject = JObject.Parse(json);

            JArray array = (JArray)jsonObject["drinks"];

            return array.Select(obj => obj.ToObject<Cocktail>());
        }
    }
}