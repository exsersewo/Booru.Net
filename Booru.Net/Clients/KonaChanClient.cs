using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class KonaChanClient : IDisposable
    {
        private readonly HttpClient _api;
        private readonly JsonSerializerSettings settings;

        public KonaChanClient()
        {
            _api = new HttpClient
            {
                BaseAddress = new Uri("https://konachan.com/")
            };
            _api.DefaultRequestHeaders.Add("User-Agent", $"Booru.Net/v{Props.LibraryVersion} (https://github.com/exsersewo/Booru.Net)");

            settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public Task<IReadOnlyList<KonaChanImage>> GetImagesAsync(IEnumerable<string> tags)
            => GetImagesAsync(string.Join("%20", tags));

        public Task<IReadOnlyList<KonaChanImage>> GetImagesAsync(params string[] tags)
            => GetImagesAsync(string.Join("%20", tags));

        public async Task<IReadOnlyList<KonaChanImage>> GetImagesAsync(string tags)
        {
            var get = await _api.GetAsync($"post.json?tags={tags}").ConfigureAwait(false);

            if (!get.IsSuccessStatusCode)
                throw new HttpRequestException($"Response failed with reason: \"({get.StatusCode}) {get.ReasonPhrase}\"");

            var content = await get.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IReadOnlyList<KonaChanImage>>(content, settings);
        }

        public void Dispose()
        {

        }
    }
}
