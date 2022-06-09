using WebClient.Entities;

namespace WebClient {
    public class UsersContext : DbContext{
        public string DbPath { get; }
        public DbSet<BotUser> Users { get; set; }
        public UsersContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "BotUsers");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


    }
}
