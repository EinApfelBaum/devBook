using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ElephantClient
{
    public class Application : IApplication
    {
        private readonly ILogger<Application> _log;
        private readonly IElephantClient _elephantClient;

        public Application(ILogger<Application> log, IElephantClient elephantClient)
        {
            _log = log;
            _elephantClient = elephantClient;
        }

        public async Task Run()
        {
            _log.LogInformation("Started =)");

            var elephants = await _elephantClient.GetElephants();
            foreach (var elephant in elephants)
            {
                // structured logging
                _log.LogInformation("Elephant: {index} - {name} - {image} - {wikilink}", elephant.Index, elephant.Name, elephant.Image, elephant.Wikilink);
            }
        }
    }
}