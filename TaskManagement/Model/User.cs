namespace TaskManagement.Model
{
    public class User
    {
        public int UsertID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
