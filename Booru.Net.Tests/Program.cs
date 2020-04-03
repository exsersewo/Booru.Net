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
                Console.WriteLine(client);

                string[] tags = new[] { "corona" };

                switch (client)
                {
                    case 0:
                        {
                            var posts = await new DanbooruClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z=>tags.Contains(z) != null)));
                        }
                        break;
                    case 1:
                        {
                            var p = await new E621Client().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(p.Posts.All(x => x.Tags.Any(z => z.Value.Any(y => tags.Contains(y)))));
                        }
                        break;
                    case 2:
                        {
                            var posts = await new GelbooruClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                    case 3:
                        {
                            var posts = await new KonaChanClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                    case 4:
                        {
                            var posts = await new RealbooruClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                    case 5:
                        {
                            var posts = await new Rule34Client().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                    case 6:
                        {
                            var posts = await new SafebooruClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                    case 7:
                        {
                            var posts = await new YandereClient().GetImagesAsync(tags).ConfigureAwait(false);
                            Console.WriteLine(posts.Any(x => x.Tags.Any(z => tags.Contains(z) != null)));
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
