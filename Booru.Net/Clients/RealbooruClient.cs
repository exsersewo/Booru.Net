using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class RealbooruClient : IPHPBooruClient<RealbooruImage>, IDisposable
    {
        IPHPBooruClient<RealbooruImage> _api;

        public RealbooruClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://realbooru.com/")
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
            }.For<IPHPBooruClient<RealbooruImage>>();
        }

        public async Task<IReadOnlyList<RealbooruImage>> GetImagesAsync(IEnumerable<string> tags)
            => await _api.GetImagesAsync(tags).ConfigureAwait(false);

        public async Task<IReadOnlyList<RealbooruImage>> GetImagesAsync(params string[] tags)
            => await _api.GetImagesAsync(tags).ConfigureAwait(false);

        public void Dispose()
        {

        }
    }
}
