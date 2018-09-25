namespace Booru.Net
{
    public class E621Image : GelbooruImage
	{
        public override string PostUrl { get { return "https://e621.net/post/show/" + ID; } }
	}
}
