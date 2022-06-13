using WebClient.Models;

namespace WebClient.Commands {
    public class StartCommand : BaseCommand {
        public override string Name => CommandNames.StartCommand;
        
        private readonly TelegramBotClient _botClient;
        public StartCommand(TelegramBot telegramBot) {
            _botClient = telegramBot.GetBot().Result;
        }

        public override async Task ExecuteAsync(Update update) {

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            Message sentMessage = await _botClient.SendTextMessageAsync(chatId, messageText);
        }
    }
}
