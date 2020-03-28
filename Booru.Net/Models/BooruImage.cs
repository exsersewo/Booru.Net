using Newtonsoft.Json;

namespace Booru.Net
{
    public class BooruImage
	{
		[JsonProperty("id")]
		public int ID { get; set; }

		[JsonProperty("rating")]
		private string Prating { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual string PostUrl { get; set; }

		public Rating Rating
		{
			get
			{
				if(Prating.ToLowerInvariant().StartsWith("s"))
				{
					return Rating.Safe;
				}
				if(Prating.ToLowerInvariant().StartsWith("q"))
				{
					return Rating.Questionable;
				}
				if(Prating.ToLowerInvariant().StartsWith("e"))
				{
					return Rating.Explicit;
				}
				return Rating.None;
			}
		}
	}
}
