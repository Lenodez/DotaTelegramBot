namespace WebClient.Modules {
    public interface ICommandExecutor {
        Task Execute(Update update);
    }
}
