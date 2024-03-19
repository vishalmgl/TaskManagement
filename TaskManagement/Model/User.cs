namespace TaskManagement.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public ICollection<TaskAssignment> TasksAssigned { get; set; }
    }
}
