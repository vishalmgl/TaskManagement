namespace TaskManagement.Model
{
    public class TaskAssignment
    {
        public int TaskAssigmentId { get; set; }
        public ICollection<Task>tasks { get; set; }
        public ICollection<User> users { get; set; }
    }
}
