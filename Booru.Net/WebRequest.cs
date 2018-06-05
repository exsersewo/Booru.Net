using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace Booru.Net
{
    class WebRequest
    {
		public static HttpWebRequest CreateWebRequest(Uri uri)
		{
			var cli = (HttpWebRequest)System.Net.WebRequest.Create(uri);

			cli.AllowAutoRedirect = true;
			cli.KeepAlive = false;
			cli.Timeout = 20000;
			cli.ProtocolVersion = HttpVersion.Version10;

			return cli;
		}
		public static async Task<string> ReturnStringAsync(Uri url)
		{
			try
			{
				var client = CreateWebRequest(url);

				var resp = (HttpWebResponse)(await client.GetResponseAsync());
				if (resp.StatusCode == HttpStatusCode.OK)
				{
					var reader = new StreamReader(resp.GetResponseStream());
					var responce = await reader.ReadToEndAsync();
					resp.Dispose();
					client.Abort();
					return responce;
				}
				else
				{
					resp.Dispose();
					client.Abort();
					return null;
				}
			}
			catch
			{
				return null;
			}
		}
	}
}
