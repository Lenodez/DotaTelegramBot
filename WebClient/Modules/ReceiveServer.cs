using Telegram.Bot.Extensions.Polling;
using WebClient.Handlers;

namespace WebClient.Modules {
    public class ReceiveServer {
        public ReceiveServer() {
            StartReceive();
        }

        private async void StartReceive() {
            var botClient = new TelegramBotClient("5399368976:AAEe6hPV9PAv2DjDCRmXCDqJueKps-K9w34");

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };


            botClient.StartReceiving(
                UpdateHandler.HandleUpdateAsync,
                ErrorHandler.HandlePollingErrorAsync,
                receiverOptions);
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            
        }
    }
}
