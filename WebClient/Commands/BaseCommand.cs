using System.Threading.Tasks;
namespace WebClient.Commands {
    public abstract class BaseCommand {
        public abstract string Name { get; }
        public abstract Task ExecuteAsync(Update update);
    }
}
