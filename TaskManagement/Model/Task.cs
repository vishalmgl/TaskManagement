namespace TaskManagement.Model
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public ICollection<TaskAssignment> AssignedUsers { get; set; }
    }
}
