using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class SafebooruClient : IPHPBooruClient<SafebooruImage>, IDisposable
    {
        IPHPBooruClient<SafebooruImage> _api;

        public SafebooruClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://safebooru.org/")
            };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Booru.Net/v{Props.LibraryVersion} (https://github.com/exsersewo/Booru.Net)");

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            _api = new RestClient(httpClient)
            {
                JsonSerializerSettings = settings
            }.For<IPHPBooruClient<SafebooruImage>>();
        }

        public Task<IReadOnlyList<SafebooruImage>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<SafebooruImage>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {

        }
    }
}
