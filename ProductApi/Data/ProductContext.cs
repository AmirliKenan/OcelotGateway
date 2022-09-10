using Microsoft.EntityFrameworkCore;
using ProductApi.Model;

namespace ProductApi.Data
{
    public class ProductContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public ProductContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlServer(_configuration.GetConnectionString("ProductConnection"));
        
        }
        public DbSet<Product> Products { get; set; }
    }
}
