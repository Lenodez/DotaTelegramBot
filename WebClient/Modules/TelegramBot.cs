using Telegram.Bot.Extensions.Polling;

namespace WebClient.Modules {
    public class TelegramBot {
        private readonly IConfiguration _configuration;
        private readonly IUpdateHandler _updateHandler;
        private TelegramBotClient _botClient;
        public TelegramBot(IConfiguration configuration, IUpdateHandler updateHandler) {
            _updateHandler = updateHandler;
            _configuration = configuration;            
        }

        public async Task<TelegramBotClient> GetBot() {
            if(_botClient != null) {
                return _botClient;
            }
            _botClient = new TelegramBotClient(_configuration["Token"]);
            var receiverOptions = new ReceiverOptions {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            _botClient.StartReceiving(_updateHandler, receiverOptions);
            var me = await _botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");

            return _botClient;
        }
    }
}
