using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booru.Net.Tests
{
    class Program
    {
        static void Main(string[] args) => StartAsync().GetAwaiter().GetResult();

        static async Task StartAsync()
        {
            for (int x = 0; x < 8; x++)
                await DoClientTest(x).ConfigureAwait(false);

            Console.ReadLine();
        }

        static async Task DoClientTest(int client)
        {
            try
            {
                IEnumerable<BooruImage> posts = null;

                Console.WriteLine(client);

                switch(client)
                {
                    case 0:
                        posts = await new DanbooruClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 1:
                        var p = await new E621Client().GetImagesAsync().ConfigureAwait(false);
                        Console.WriteLine(p.Posts.Any(x => x.ImageUrl != null));
                        break;
                    case 2:
                        posts = await new GelbooruClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 3:
                        posts = await new KonaChanClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 4:
                        posts = await new RealbooruClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 5:
                        posts = await new Rule34Client().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 6:
                        posts = await new SafebooruClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                    case 7:
                        posts = await new YandereClient().GetImagesAsync().ConfigureAwait(false);
                        break;
                }

                if (posts != null)
                {
                    Console.WriteLine(posts.Any(x => x.ImageUrl != null));
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
