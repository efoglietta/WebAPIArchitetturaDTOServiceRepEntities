using ArchitetturaDTOEntities.DTO;
using ArchitetturaDTOEntities.Entities;
using ArchitetturaDTOEntities.Repository;
using AutoMapper;

namespace ArchitetturaDTOEntities.Services
{
    public class ProdottiServiceDTO : IProdottiServiceDTO
    {
        private IMapper _mapper;
        private IProdottiRepository _repProdotti;
        public ProdottiServiceDTO(IMapper mapper, IProdottiRepository repProdotti)
            => (_mapper, _repProdotti) = (mapper, repProdotti);
        public async Task<int> CreaProdotto(CreaProdottoDto p)
        {

            //crea entity da DTO
            var prodotto = _mapper.Map<Prodotto>(p);
            await _repProdotti.InserisciProdottoAsync(prodotto);
            return prodotto.IdProdotto;
        }
        public Task AggiornaProdotto(AggiornaProdottoDTO p)
        {
            throw new NotImplementedException();
        }

        public Task CancellaProdotto(EliminaProdottoDto p)
        {
            throw new NotImplementedException();
        }

        

        public Task<List<ProdottoDTO>> RestituisciProdotti()
        {
            throw new NotImplementedException();
        }

        public Task<ProdottoDTO> RestituisciProdotto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
