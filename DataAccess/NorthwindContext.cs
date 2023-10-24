using ArchitetturaDTOEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArchitetturaDTOEntities.DataAccess
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {

        }
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<Prodotto> Prodotti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //validazione in Fluent mode (tecnica imperativa)
            modelBuilder.Entity<Prodotto>(entity =>
            {
                entity.HasKey(e => e.IdProdotto);

                entity.Property(e => e.NomeProdotto).IsRequired();
                entity.Property(e => e.Prezzo).IsRequired();
                entity.Property(e => e.Giacenza).IsRequired();

            });

            //}

        }
    }
}
