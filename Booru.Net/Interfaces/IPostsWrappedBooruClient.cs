using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booru.Net
{
    public interface IPostsWrappedBooruClient<T> : IDisposable
    {
        [Get("posts.json")]
        public Task<T> GetImagesAsync([Query("tags")] IEnumerable<string> tags);
    }
}
