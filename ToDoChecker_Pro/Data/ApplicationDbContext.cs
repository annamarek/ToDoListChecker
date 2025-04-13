using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoChecker_Pro.Models;

namespace ToDoChecker_Pro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoTask>().HasData(
                new ToDoTask { Id = 1, Name = "Go to the gym"},
                new ToDoTask { Id = 2, Name = "Visit cosmetologist" },
                new ToDoTask { Id = 3, Name = "Cook dinner" }
                );
        }
    }
}
