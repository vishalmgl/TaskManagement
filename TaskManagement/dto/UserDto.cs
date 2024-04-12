namespace TaskManagement.dto
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<TaskDto> TasksAssigned { get; set; }
    }
}
