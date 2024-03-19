
using TaskManagement.Data;
using TaskManagement.Model;
 

namespace TaskManagement
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Tasks.Any())
            {
                var tasks = new List<Model.Task>
                {
                    new Model.Task
                    {
                        Title = "Task 1",
                        Description = "Description for Task 1",
                        DueDate =new DateTime(2002,1,1),
                        Status = "Pending",
                        AssignedUsers = new List<TaskAssignment>
                        {
                            new TaskAssignment { User = new User { UserName = "user1", Email = "user1@example.com" } },
                            new TaskAssignment { User = new User { UserName = "user2", Email = "user2@example.com" } }
                        }
                    },
                    new Model.Task
                    {
                        Title = "Task 2",
                        Description = "Description for Task 2",
                        DueDate =new DateTime(2002,2,1),
                        Status = "InProgress",
                        AssignedUsers = new List<TaskAssignment> 
                        {
                            new TaskAssignment { User = new User { UserName = "user3", Email = "user3@example.com" } }
                        }
                    },
                    new Model.Task
                    {
                        Title = "Task 3",
                        Description = "Description for Task 3",
                        DueDate =new DateTime (2002, 3, 1),
                        Status = "Completed",
                        AssignedUsers = new List<TaskAssignment>
                        {
                            new TaskAssignment { User = new User { UserName = "user4", Email = "user4@example.com" } },
                            new TaskAssignment { User = new User { UserName = "user5", Email = "user5@example.com" } }
                        }
                    }
                };

                _dataContext.Tasks.AddRange(tasks);
                _dataContext.SaveChanges();
            }
        }
    }
}
