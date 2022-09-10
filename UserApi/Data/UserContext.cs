using Microsoft.EntityFrameworkCore;
using UserApi.Model;

namespace UserApi.Data
{
    public class UserContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public UserContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("UserConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
