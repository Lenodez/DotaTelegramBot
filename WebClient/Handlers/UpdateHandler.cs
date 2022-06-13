using Telegram.Bot.Extensions.Polling;

namespace WebClient.Handlers {
    public class UpdateHandler : IUpdateHandler {
        private readonly ICommandExecutor _commandExecutor;
        public UpdateHandler(ICommandExecutor commandExecutor) {
            _commandExecutor = commandExecutor;
        }
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) {
            var ErrorMessage = exception switch {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) {
            await _commandExecutor.Execute(update);
        }
    }
}
