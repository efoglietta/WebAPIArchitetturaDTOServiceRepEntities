using ArchitetturaDTOEntities.DTO;

namespace ArchitetturaDTOEntities.Services
{
    public interface IProdottiServiceDTO
    {
        Task<List<ProdottoDTO>> RestituisciProdotti();
        Task<ProdottoDTO> RestituisciProdotto(int id);
        Task<int> CreaProdotto(CreaProdottoDto p);
        Task AggiornaProdotto(AggiornaProdottoDTO p);
        Task CancellaProdotto(EliminaProdottoDto p);
    }
}
