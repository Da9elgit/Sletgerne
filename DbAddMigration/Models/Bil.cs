namespace DbAddMigration.Models
{
    public class Bil
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public string? Efternavn { get; set; }
        public int? Alder { get; set; }

        public string? By { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

