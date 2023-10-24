using System.ComponentModel.DataAnnotations;

namespace ArchitetturaDTOEntities.Entities
{
    public class Prodotto
    {
        [Key]        
        public int IdProdotto { get; set; }
        [Required]
        public string? NomeProdotto { get; set; }
        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }
        public int Giacenza { get; set; }

    }
}
