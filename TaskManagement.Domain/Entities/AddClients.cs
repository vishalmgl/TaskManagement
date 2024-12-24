namespace TaskManagement.Domain.Entities
{
    public class AddClients
    {
        public int Id { get; set; }
        public string? ClientName {  get; set; }
        public string? GSTNumber { get; set; }
        public string? ClientStatusCode { get; set; }
        public string? CountryCode { get; set; }
        public string? StateCode { get; set; }
        public string? CityCode { get; set; }
        public string? Address { get; set; }
        //
        // parent entity
        //
        public ClientStatus? ClientStatus { get; set; } 
        public Country? Country { get; set; }
        public State? State { get; set; }
        public City? City { get; set; }
    }
}
