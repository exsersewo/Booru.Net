using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booru.Net
{
    public interface IPostsBooruClient<T> : IDisposable
    {
        [Get("posts.json")]
        public Task<IReadOnlyList<T>> GetImagesAsync([Query("tags")] IEnumerable<string> tags);
    }
}
