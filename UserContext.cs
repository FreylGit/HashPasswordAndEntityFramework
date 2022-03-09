using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }
        public string DbPath { get; }

        public UserContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "userData.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite($"Data Source={DbPath}");
    }
}
