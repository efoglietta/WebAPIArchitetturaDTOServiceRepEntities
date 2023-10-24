using ArchitetturaDTOEntities.Entities;
using ArchitetturaDTOEntities.Repository;

namespace ArchitetturaDTOEntities.Services
{
    public class GenericProdottiService : IGenericProdottiService
    {
        private IGenericRepositoryAsync<Prodotto> _repGenericRepository;
        public GenericProdottiService(IGenericRepositoryAsync<Prodotto> repGenericRepository)
        => _repGenericRepository = repGenericRepository;
        
        public async Task<Prodotto> RestituisciProdotto(int id)
        {
            return await _repGenericRepository.GetSingleAsync(id);  
        }
    }
}
