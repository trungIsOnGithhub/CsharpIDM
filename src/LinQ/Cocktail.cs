using ConsoleApplication;
using Generics;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace CocktailModule
{
    class ModuleConst
    {
        static internal readonly string baseURI = "https://www.thecocktaildb.com/api/json";
    }
    public class Cocktail
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strGlass { get; set; }
        public string strCategory { get; set; }
        public string strAlcoholic { get; set; }

        public override string ToString()
        {
            return strDrink;
        }
    }

    public class CocktailModel
    {
        public string VersionString { get; set; }

        private readonly HttpClient httpModule;

        public CocktailModel()
        {
            httpModule = new HttpClient();

            httpModule.DefaultRequestHeaders.Accept.Clear();
            httpModule.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpModule.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        private string constructURI(string path, string query)
        {
            return ModuleConst.baseURI + "/" + VersionString + "/" + KeyVault.getKeyFor(ModuleConst.baseURI)  + "/" + path + query;
        }

        public async void getCocktailByFirstLetter(char firstLetter)
        {
            string specificURI = constructURI("search.php", $"?f={firstLetter}");

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

            // Console.WriteLine($"RESPONSE: |{responseContent.GetType()}|");

            IEnumerable<Cocktail> cocktails = getCocktaiListFromJson(responseContent);

            EnumerablePrint<Cocktail>.printEnumerableByComma(cocktails);

            // cocktailList.Where(cocktail => cocktail.strAlcoholic == "alcoholic")
                        // .ToList().ForEach(cocktail => Console.WriteLine(cocktail.strDrink));
            // Console.WriteLine($"LENGTH : {cocktailList.drinks.Length}");
        }

        private static IEnumerable<Cocktail> getCocktaiListFromJson(string json)
        {
            JObject jsonObject = JObject.Parse(json);

            JArray array = (JArray)jsonObject["drinks"];

            return array.Select(obj => obj.ToObject<Cocktail>());
        }
    }
}