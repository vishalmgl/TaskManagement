namespace TaskManagement.Domain.Entities
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string? ContactPerson {  get; set; }
        public string? ContactNumber { get; set; }
        public string? MailID { get; set; }
    }
}
