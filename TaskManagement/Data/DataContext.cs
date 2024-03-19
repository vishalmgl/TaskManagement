using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Data
{
    // DataContext class inherits from DbContext
    public class DataContext : DbContext
    {
        // Constructor with DbContextOptions parameter
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Define DbSet for each entity
        public DbSet<Model.Task> Tasks { get; set; } // DbSet for Task entity//contains system.threading.tasks.task so using model
        public DbSet<User> Users { get; set; } // DbSet for User entity
        public DbSet<TaskAssignment> TaskAssignments { get; set; } // DbSet for TaskAssignment entity

        // Override OnModelCreating method to configure entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for TaskAssignment entity
            modelBuilder.Entity<TaskAssignment>()
                .HasKey(ta => ta.TaskAssignmentID);

            // TaskAssignment has one Task with many assigned users
            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.Task)
                .WithMany(t => t.AssignedUsers) // Collection of User entities assigned to this task
                .HasForeignKey(ta => ta.TaskID); // Foreign key

            // TaskAssignment has one User with many assigned tasks
            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.User)
                .WithMany(u => u.TasksAssigned) // Collection of Task entities assigned to this user
                .HasForeignKey(ta => ta.UserID); // Foreign key
        }
    }
}
