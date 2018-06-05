namespace Booru.Net
{
    public class YandereImage : GelbooruImage
	{
		public override string PostUrl { get { return "https://yande.re/post/show/" + ID; } }
	}
}
