namespace WebClient.Modules {
    public class DataBaseModule {

        public UsersContext usersContext;
        public DataBaseModule() {
            usersContext = new UsersContext();
        }
    }
}
