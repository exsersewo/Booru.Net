using Newtonsoft.Json;
using System.Collections.Generic;

namespace Booru.Net
{
    public class SafebooruImage : BooruImage
	{
		[JsonProperty("directory")]
		public string Directory { get; set; }

        [JsonProperty("hash")]
		public string Hash { get; set; }

		[JsonProperty("height")]
		public int Height { get; set; }

		[JsonProperty("image")]
		public string Image { get; set; }

		[JsonProperty("change")]
		public ulong Change { get; set; }

		[JsonProperty("owner")]
		public string Owner { get; set; }

		[JsonProperty("parent_id")]
		public int? ParentID { get; set; }

		[JsonProperty("sample")]
		public bool Sample { get; set; }

		[JsonProperty("sample_height")]
		public int SampleHeight { get; set; }

		[JsonProperty("sample_width")]
		public int SampleWidth { get; set; }

		[JsonProperty("tags")]
		private string Ptags { get; set; }

		[JsonProperty("width")]
		public int Width { get; set; }

		public IReadOnlyList<string> Tags 
            => Ptags.Split(' ');

		public override string ImageUrl
			=> "https://safebooru.org/images/" + Directory + "/" + Image;

		public override string PostUrl
			=> "https://safebooru.org/index.php?page=post&s=view&id=" + ID;
	}
}
