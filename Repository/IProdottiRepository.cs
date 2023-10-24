using ArchitetturaDTOEntities.Entities;

namespace ArchitetturaDTOEntities.Repository
{
    public interface IProdottiRepository
    {
        Task<List<Prodotto>> GetProdottiAsync();
        Task<int> InserisciProdottoAsync(Prodotto prodotto);
        Task<int> ModificaProdottoAsync(Prodotto prodotto);
        Task<Prodotto> GetProdottoAsync(int id);
    }
}
