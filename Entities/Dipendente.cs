namespace ArchitetturaDTOEntities.Entities
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? CF { get; set; }
        public string? Email { get; set; }
        public char? Genere { get; set; }
        public int? Eta { get; set; }

        public decimal Ral { get; set; }

     
    }
}
