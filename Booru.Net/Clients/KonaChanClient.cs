using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class KonaChanClient : IPostBooruClient<KonaChanImage>, IDisposable
    {
        IPostBooruClient<KonaChanImage> _api;

        public KonaChanClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://konachan.com/")
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
            }.For<IPostBooruClient<KonaChanImage>>();
        }

        public Task<IReadOnlyList<KonaChanImage>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<KonaChanImage>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {

        }
    }
}
