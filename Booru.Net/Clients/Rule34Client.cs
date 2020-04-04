using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class Rule34Client : IDisposable
    {
        private readonly HttpClient _api;
        private readonly JsonSerializerSettings settings;

        public Rule34Client()
        {
            _api = new HttpClient
            {
                BaseAddress = new Uri("https://rule34.xxx/")
            };
            _api.DefaultRequestHeaders.Add("User-Agent", $"Booru.Net/v{Props.LibraryVersion} (https://github.com/exsersewo/Booru.Net)");

            settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public Task<IReadOnlyList<Rule34Image>> GetImagesAsync(IEnumerable<string> tags)
            => GetImagesAsync(string.Join("%20", tags));

        public Task<IReadOnlyList<Rule34Image>> GetImagesAsync(params string[] tags)
            => GetImagesAsync(string.Join("%20", tags));

        public async Task<IReadOnlyList<Rule34Image>> GetImagesAsync(string tags)
        {
            var get = await _api.GetAsync($"index.php?page=dapi&s=post&q=index&json=1&tags={tags}").ConfigureAwait(false);

            if (!get.IsSuccessStatusCode)
                throw new HttpRequestException($"Response failed with reason: \"({get.StatusCode}) {get.ReasonPhrase}\"");

            var content = await get.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IReadOnlyList<Rule34Image>>(content, settings);
        }

        public void Dispose()
        {

        }
    }
}
