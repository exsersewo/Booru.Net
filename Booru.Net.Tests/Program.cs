﻿using System.Threading.Tasks;
using System;

namespace Booru.Net.Tests
{
    class Program
    {
        static void Main(string[] args) => StartAsync().GetAwaiter().GetResult();


        static async Task StartAsync()
        {
            var BooruClient = new BooruClient();

            var posts = await BooruClient.GetSafebooruImagesAsync();

            Console.ReadLine();
        }
    }
}
