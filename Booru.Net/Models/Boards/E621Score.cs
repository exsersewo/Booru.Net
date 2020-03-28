using Newtonsoft.Json;

namespace Booru.Net
{
    public class E621Score
	{
		[JsonProperty("up")]
		public int Up { get; set; }

		[JsonProperty("down")]
		public int Down { get; set; }

		[JsonProperty("total")]
		public int Total { get; set; }
	}
}
