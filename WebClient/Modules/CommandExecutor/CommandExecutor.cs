
using WebClient.Models;

namespace WebClient.Modules {
    public class CommandExecutor : ICommandExecutor {
        private readonly List<BaseCommand> _commands;
        
        private BaseCommand _lastCommand;

        public CommandExecutor(IServiceProvider serviceProvider) {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();                       
        }
        public async Task Execute(Update update) {            
            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand)) {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }
        }

        private async Task ExecuteCommand(string commandName, Update update) {
            _lastCommand = _commands.First(x => x.Name == commandName);
            await _lastCommand.ExecuteAsync(update);
        }
    }
}
