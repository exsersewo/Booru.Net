using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Booru.Net
{
	public class BooruClient
	{
        public async Task<IReadOnlyList<SafebooruImage>> GetSafebooruImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://safebooru.org/index.php?page=dapi&s=post&q=index&json=1&tags=" + tagstring));

			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<SafebooruImage>>(data);
				return posts;
			}

			return null;
		}
		public async Task<IReadOnlyList<Rule34Image>> GetRule34ImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://rule34.xxx/index.php?page=dapi&s=post&q=index&json=1&tags=" + tagstring));
			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<Rule34Image>>(data);
				return posts;
			}

			return null;
		}
		public async Task<IReadOnlyList<RealbooruImage>> GetRealBooruImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://realbooru.com/index.php?page=dapi&s=post&q=index&json=1&tags=" + tagstring));
			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<RealbooruImage>>(data);
				return posts;
			}

			return null;
		}
		public async Task<IReadOnlyList<DanbooruImage>> GetDanbooruImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://danbooru.donmai.us/posts.json?tags=" + tagstring));
			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<DanbooruImage>>(data);
				return posts;
			}

			return null;
		}
		public async Task<IReadOnlyList<GelbooruImage>> GetGelbooruImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://gelbooru.com/index.php?page=dapi&s=post&q=index&json=1&tags=" + tagstring));

			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<GelbooruImage>>(data);
				return posts;
			}
			else return null;
		}
		public async Task<IReadOnlyList<KonaChanImage>> GetKonaChanImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://konachan.com/post.json?tags=" + tagstring));

			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<KonaChanImage>>(data);
				return posts;
			}
			else return null;
		}
		public async Task<IReadOnlyList<E621Image>> GetE621ImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://e621.net/post/index.json?tags=" + tagstring));

			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<E621Image>>(data);
				return posts;
			}
			else return null;
		}
		public async Task<IReadOnlyList<YandereImage>> GetYandereImagesAsync(IEnumerable<string> tags)
		{
			IList<string> newtags = tags.ToList();
			var tagstring = String.Join("%20", newtags);

			var data = await WebRequest.ReturnStringAsync(new Uri("https://yande.re/post.json?tags=" + tagstring));

			if (data != null)
			{
				var posts = JsonConvert.DeserializeObject<List<YandereImage>>(data);
				return posts;
			}
			else return null;
		}
	}
}
