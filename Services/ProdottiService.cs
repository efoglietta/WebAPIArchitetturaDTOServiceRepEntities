using ArchitetturaDTOEntities.Entities;
using ArchitetturaDTOEntities.Repository;


namespace ArchitetturaDTOEntities.Services
{
    public class ProdottiService: IProdottiService
    {
        private IProdottiRepository _repProdotti;

        public ProdottiService(IProdottiRepository repProdotti) => _repProdotti = repProdotti;   

        public async Task AggiornaProdotto(Prodotto p)
        {
            await _repProdotti.ModificaProdottoAsync(p);
        }

        public async Task CancellaProdotto(Prodotto p)
        {
            throw new NotImplementedException();
        }

        public async Task CreaProdotto(Prodotto p)
        {
            await _repProdotti.InserisciProdottoAsync(p);
        }
       

        public async Task<List<Prodotto>> RestituisciProdotti()
        {
            return await _repProdotti.GetProdottiAsync();
        }

        

        public async Task<Prodotto> RestituisciProdotto(int id)
        {
            return await _repProdotti.GetProdottoAsync(id);
        }
    }
}
