using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace wepApi.Models
{
    public class ProductContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Products> _products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Book" },
                new Products { Id = 2, Name = "Coffy" },
                new Products { Id = 3, Name = "Television" },
                new Products { Id = 4, Name = "Pencil" }
            );
        }
    }
}
