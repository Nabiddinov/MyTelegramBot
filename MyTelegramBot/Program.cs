using Telegram.Bot;
using Telegram.Bot.Polling;

namespace MyTelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var token = builder.Configuration.GetValue("BotToken", string.Empty);

            //builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>();
            builder.Services.AddSingleton(P => new TelegramBotClient(token));
            builder.Services.AddHostedService<BotBackgroundService>();
            builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();


            var app = builder.Build();

            app.Run();
        }
    }
}