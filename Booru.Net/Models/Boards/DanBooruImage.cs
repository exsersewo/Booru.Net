using Newtonsoft.Json;
using System.Collections.Generic;

namespace Booru.Net
{
    public class DanbooruImage : BooruImage
	{
		[JsonProperty("score")]
		public int? Score { get; set; }

		[JsonProperty("tag_string")]
		private string TagString { get; set; }

		public IReadOnlyList<string> Tags { get { return TagString.Split(' '); } }
		
		public virtual string PostUrl { get { return "https://danbooru.donmai.us/posts/" + ID; } }
    }
}
