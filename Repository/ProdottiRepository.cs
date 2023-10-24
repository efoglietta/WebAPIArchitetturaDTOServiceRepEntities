using ArchitetturaDTOEntities.DataAccess;
using ArchitetturaDTOEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArchitetturaDTOEntities.Repository
{
    public class ProdottiRepository : IProdottiRepository
    {
        private NorthwindContext _nwContext;
        public ProdottiRepository(NorthwindContext nwContext)
        {
            _nwContext=nwContext;
        }
       
        public async Task<List<Prodotto>> GetProdottiAsync()
        {
            //using  Microsoft.EntityFrameworkCore per ToListAsync;
            return await _nwContext.Prodotti.ToListAsync();

          
        }

        public async Task<int> InserisciProdottoAsync(Prodotto prodotto)
        {
           await _nwContext.AddAsync(prodotto);
         return await  _nwContext.SaveChangesAsync();
        }
        
        public async Task<Prodotto> GetProdottoAsync(int id)
        {
            return await _nwContext.Prodotti.FindAsync(id);
        }

        public async Task<int> ModificaProdottoAsync(Prodotto prodotto)
        {
            _nwContext.Entry(prodotto).State = EntityState.Modified;
            try
            {
              return  await _nwContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdottoExists(prodotto.IdProdotto))
                {
                    throw new Exception("Non trovato");
                }
                else
                {
                    throw;
                }
            }
          
        }

       
        

        
        public async Task<int> DeleteProdotto(int id)
        {           
            var prodotto = await _nwContext.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                throw new Exception("Prodotto inesistente");
            }

           _nwContext.Prodotti.Remove(prodotto);
          return  await _nwContext.SaveChangesAsync();

           
        }

        private bool ProdottoExists(int id)
        {
            return (_nwContext.Prodotti?.Any(e => e.IdProdotto == id)).GetValueOrDefault();
        }

        
    }
}
