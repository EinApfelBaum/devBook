using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ElephantClient
{
    public record Elephant(int Index, string Name, string Image, string Wikilink);

    public class ElephantClient : IElephantClient
    {
        private readonly HttpClient _client;

        public ElephantClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Elephant>> GetElephants()
        {
            return await _client.GetFromJsonAsync<Elephant[]>("elephants");
        }
    }
}