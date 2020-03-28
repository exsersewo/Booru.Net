using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booru.Net
{
    public interface IIndexBooruClient<T> : IDisposable
    {
        [Get("index.json")]
        public Task<IReadOnlyList<T>> GetImagesAsync([Query("tags")] IEnumerable<string> tags);
    }
}
