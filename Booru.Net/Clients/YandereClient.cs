using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class YandereClient : IPostBooruClient<YandereImage>, IDisposable
    {
        IPostBooruClient<YandereImage> _api;

        public YandereClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://yande.re/")
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
            }.For<IPostBooruClient<YandereImage>>();
        }

        public Task<IReadOnlyList<YandereImage>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<YandereImage>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {
            
        }
    }
}
