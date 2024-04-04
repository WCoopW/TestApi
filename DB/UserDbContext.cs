using System.Data.Entity;
using RestWeb.Models;

namespace RestWeb.DB
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("name=UserDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UsersData { get; set; }
    }
}
