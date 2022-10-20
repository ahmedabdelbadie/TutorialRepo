using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppTutorial.Models;

namespace WebAppTutorial.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                 new Employee() { Id = 1, Name = "Ahmed", Email = "Ahmed@mail.com", Department = Dep.HR },
                new Employee() { Id = 2, Name = "Mohamed", Email = "Mohamed@mail.com", Department = Dep.Financial },
                new Employee() { Id = 3, Name = "Yosef", Email = "Yosef@mail.com", Department = Dep.Selling }
                );
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e=>e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        

        
    }
}
