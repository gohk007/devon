using devonbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace devonbackend.Dbcontexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User { ID=1,NAME="Test",EMAIL="Test@gmail.com",ADDRESS="Address",COMPANY="Devon"});


        }



    }
}
