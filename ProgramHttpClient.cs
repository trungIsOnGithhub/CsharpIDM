using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

const string uri = "https://khodattenqua.azurewebsites.net/api/HttpTrigger1";

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
);
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.PostAsync(uri,
        JsonContent.Create(
            new Request{name = "HIHIHIHI"},
            new MediaTypeWithQualityHeaderValue("application/json")
        )
);
    Console.Write(json.Content);
}


class Request {
    public string name { get; set; }
}