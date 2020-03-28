using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class GelbooruClient : IPHPBooruClient<GelbooruImage>, IDisposable
    {
        IPHPBooruClient<GelbooruImage> _api;

        public GelbooruClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://gelbooru.com/")
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
            }.For<IPHPBooruClient<GelbooruImage>>();
        }

        public Task<IReadOnlyList<GelbooruImage>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<GelbooruImage>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {

        }
    }
}
