using Booru.Net.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Booru.Net
{
    public class E621Image : BooruImage
	{
		[JsonProperty("score")]
		public E621Score Score { get; set; }

		[JsonProperty("directory")]
		public string Directory { get; set; }

		[JsonProperty("file")]
		public E621ImageSource File { get; set; }

		[JsonProperty("preview")]
		public E621ImageSource PreviewImage { get; set; }

		[JsonProperty("sample")]
		public E621ImageSource SampleImage { get; set; }

		[JsonProperty("flags")]
		public E621ImageFlags Flags { get; set; }

		[JsonProperty("tags")]
		[JsonConverter(typeof(TagGroupConverter))]
		private List<Dictionary<string, List<string>>> PTags { get; set; }

		public IReadOnlyList<Dictionary<string, List<string>>> Tags { get { return PTags.AsReadOnly(); } }

		public override string ImageUrl => File.Url;

		public override string PostUrl { get { return "https://e621.net/post/show/" + ID; } }
	}
}
