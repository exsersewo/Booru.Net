using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class DanbooruClient : IPostsBooruClient<DanbooruImage>, IDisposable
    {
        IPostsBooruClient<DanbooruImage> _api;

        public DanbooruClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://danbooru.donmai.us/")
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
            }.For<IPostsBooruClient<DanbooruImage>>();
        }

        public Task<IReadOnlyList<DanbooruImage>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<DanbooruImage>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
