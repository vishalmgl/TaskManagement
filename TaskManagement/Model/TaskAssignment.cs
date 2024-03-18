namespace TaskManagement.Model
{
    public class TaskAssignment
    {
        public int TaskAssignmentID { get; set; }
        public Task Task { get; set; }
        public User User{ get; set; }
    }
}

