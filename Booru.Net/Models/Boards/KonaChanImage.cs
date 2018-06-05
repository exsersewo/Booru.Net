namespace Booru.Net
{
    public class KonaChanImage : GelbooruImage
    {
		public override string PostUrl { get { return "https://konachan.com/post/show/" + ID; } }
	}
}
