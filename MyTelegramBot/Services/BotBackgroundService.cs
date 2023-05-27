using Telegram.Bot;
using Telegram.Bot.Polling;

namespace MyTelegramBot.Services
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ITelegramBotClient _client;
        private readonly ILogger<BotBackgroundService> _logger;

        public BotBackgroundService(
            ILogger<BotBackgroundService> logger,
            ITelegramBotClient client)
        {
            _client = client;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await _client.GetMeAsync(stoppingToken);

            _logger.LogInformation("Bot Started secsusfuly: {bot.Username}", bot.Username);

            _client.StartReceiving<BotUpdateHandler>(new ReceiverOptions()
            {
                ThrowPendingUpdates = true
            }, stoppingToken);
        }
    }
}
