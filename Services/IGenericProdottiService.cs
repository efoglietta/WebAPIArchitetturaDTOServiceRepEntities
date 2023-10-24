using ArchitetturaDTOEntities.Entities;

namespace ArchitetturaDTOEntities.Services
{
    public interface IGenericProdottiService
    {
        Task<Prodotto> RestituisciProdotto(int id);
    }
}
