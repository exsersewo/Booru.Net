using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class E621Client : IDisposable
    {
        private readonly HttpClient _api;
        private readonly JsonSerializerSettings settings;

        public E621Client()
        {
            _api = new HttpClient
            {
                BaseAddress = new Uri("https://e621.net/")
            };
            _api.DefaultRequestHeaders.Add("User-Agent", $"Booru.Net/v{Props.LibraryVersion} (https://github.com/exsersewo/Booru.Net)");

            settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public Task<IReadOnlyList<E621Image>> GetImagesAsync(IEnumerable<string> tags)
            => GetImagesAsync(string.Join("%20", tags));

        public Task<IReadOnlyList<E621Image>> GetImagesAsync(params string[] tags)
            => GetImagesAsync(string.Join("%20", tags));

        public async Task<IReadOnlyList<E621Image>> GetImagesAsync(string tags)
        {
            var get = await _api.GetAsync($"posts.json?tags={tags}").ConfigureAwait(false);

            if (!get.IsSuccessStatusCode)
                throw new HttpRequestException($"Response failed with reason: \"({get.StatusCode}) {get.ReasonPhrase}\"");

            var content = await get.Content.ReadAsStringAsync().ConfigureAwait(false);

            var posts = JsonConvert.DeserializeObject<WrappedPosts<E621Image>>(content, settings);

            return posts.Posts;
        }

        public void Dispose()
        {
            
        }
    }
}
