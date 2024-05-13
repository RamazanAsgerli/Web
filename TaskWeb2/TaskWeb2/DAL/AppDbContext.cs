using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskWeb2.Models;

namespace TaskWeb2.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
