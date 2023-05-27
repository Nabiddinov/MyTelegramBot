using MyTelegramBot.Services;
using Telegram.Bot;

namespace MyTelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var token = builder.Configuration.GetValue("BotToken",string.Empty);

            //builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>();
            builder.Services.AddSingleton(new TelegramBotClient(token));
            builder.Services.AddHostedService<BotBackgroundService>();



            var app = builder.Build();

            app.Run();
        }
    }
}