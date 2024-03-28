using Microsoft.EntityFrameworkCore;

namespace wepApi.Models
{
    public class ProductContext : DbContext
    {

 

        //Connection string'i dışarıdan veririz.
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }


        //Entity Burada eklendi!
        public DbSet<Products> _products { get; set; }



        //Test verileri ekliyoruz!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(

                    new Products { Id = 1 , Name = "Book"},
                    new Products { Id = 2 , Name = "Coffy"},
                    new Products { Id = 3 , Name = "Television"},
                    new Products { Id = 4 , Name = "Pencil"}

                );
        }

    }
}
