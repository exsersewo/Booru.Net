using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class E621Client : IPostsWrappedBooruClient<WrappedPosts<E621Image>>, IDisposable
    {
        IPostsWrappedBooruClient<WrappedPosts<E621Image>> _api;

        public E621Client()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://e621.net/")
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
            }.For<IPostsWrappedBooruClient<WrappedPosts<E621Image>>>();
        }

        public Task<WrappedPosts<E621Image>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<WrappedPosts<E621Image>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {
            
        }
    }
}
