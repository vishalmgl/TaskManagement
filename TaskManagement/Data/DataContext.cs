using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Data
{//datacontext is something whhich birngs in all information and can be manipulated.it ties all database tables 
    public class DataContext : DbContext//inherits from dbcontext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)//base shows all the data pushed to dbcontext
        {

        }
        //show the context what all the tables are
        public DbSet<Model.Task> Tasks { get; set; }//there was ambiguty with task so had to use model.task
        public DbSet<User> Users { get; set; }

        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary key for the Task entity
            modelBuilder.Entity<Model.Task>()
                .HasKey(t => t.TaskID);

            // Define primary key for the User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            // Define primary key for the TaskAssignment entity
            modelBuilder.Entity<TaskAssignment>()
                .HasKey(ta => ta.TaskAssignmentID);

            // Configure the relationship between Task and TaskAssignment entities
            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.Task) // TaskAssignment has one Task
                .WithMany(t => t.AssignedUsers) // Task can have many AssignedUsers
                .HasForeignKey(ta => ta.TaskID); // Foreign key relationship

            // Configure the relationship between User and TaskAssignment entities
            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.User) // TaskAssignment has one User
                .WithMany(u => u.TasksAssigned) // User can have many TasksAssigned
                .HasForeignKey(ta => ta.UserID); // Foreign key relationship
        }


    }
}