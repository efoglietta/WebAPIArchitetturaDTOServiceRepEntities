using ArchitetturaDTOEntities.Entities;

namespace ArchitetturaDTOEntities.Services
{
    public interface IProdottiService
    {
        Task<List<Prodotto>> RestituisciProdotti();
        Task<Prodotto> RestituisciProdotto(int id);
        Task CreaProdotto(Prodotto p);
        Task AggiornaProdotto(Prodotto p);
        Task CancellaProdotto(Prodotto p);
    }
}
