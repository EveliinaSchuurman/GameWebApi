using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameWebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            FileRepository fr = new FileRepository();
            Player player = new Player();
            player.Name = "rii";
            player.Id = new Guid();
            player.IsBanned = false;
            player.Level= 0;
            player.Score = 243;
            await fr.Create(player);
            Player player1 = new Player();
            player1.Name = "riifdg";
            player1.Id = new Guid();
            player1.IsBanned = false;
            player1.Level= 0;
            player1.Score = 443;
            await fr.Create(player1);
            Player[] players;
            players = await fr.GetAll();
            Console.WriteLine(players[0].Name);
            Console.WriteLine(players[1].Name);
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
