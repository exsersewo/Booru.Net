using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booru.Net
{
    public class Rule34Client : IPHPBooruClient<Rule34Image>, IDisposable
    {
        IPHPBooruClient<Rule34Image> _api;

        public Rule34Client()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://rule34.xxx/")
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
            }.For<IPHPBooruClient<Rule34Image>>();
        }

        public Task<IReadOnlyList<Rule34Image>> GetImagesAsync(IEnumerable<string> tags)
            => _api.GetImagesAsync(tags);

        public Task<IReadOnlyList<Rule34Image>> GetImagesAsync(params string[] tags)
            => _api.GetImagesAsync(tags);

        public void Dispose()
        {

        }
    }
}
