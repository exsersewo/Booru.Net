using Newtonsoft.Json;

namespace Booru.Net
{
    public class E621Score
	{
		[JsonProperty("up")]
		public int Up { get; set; }

		[JsonProperty("down")]
		private int Down { get; set; }

		[JsonProperty("total")]
		private int Total { get; set; }
	}
}
