using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booru.Net
{
    public interface IPHPBooruClient<T> : IDisposable
    {
        [Get("index.php?page=dapi&s=post&q=index&json=1")]
        public Task<IReadOnlyList<T>> GetImagesAsync([Query("tags")] IEnumerable<string> tags);
    }
}
