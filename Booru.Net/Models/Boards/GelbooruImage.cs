using Newtonsoft.Json;
using System.Collections.Generic;

namespace Booru.Net
{
    public class GelbooruImage : BooruImage
	{
		[JsonProperty("score")]
		public int? Score { get; set; }

		[JsonProperty("directory")]
		public string Directory { get; set; }

		[JsonProperty("file_url")]
		private string FileUrl { get; set; }

		public override string ImageUrl
			=> FileUrl;

		[JsonProperty("tags")]
		private string Ptags { get; set; }

		public IReadOnlyList<string> Tags { get { return Ptags.Split(' '); } }

		public virtual string PostUrl { get { return "https://gelbooru.com/index.php?page=post&s=view&id=" + ID; } }
	}
}