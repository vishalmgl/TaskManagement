using System.Collections.Generic;

namespace TaskManagement.Domain.Entities
{
    public class Country
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        //
        // child entity
        //
        public ICollection<AddClients>? AddClients { get; set; }
    }
}
