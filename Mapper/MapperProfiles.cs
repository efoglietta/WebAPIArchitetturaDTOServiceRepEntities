using ArchitetturaDTOEntities.DTO;
using ArchitetturaDTOEntities.Entities;
using AutoMapper;

namespace ArchitetturaDTOEntities.Mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<ProdottoDTO,Prodotto>()
                //necessario solo per i campi con nome diverso
                .ForMember(dest=>dest.IdProdotto,opt=>opt.MapFrom(source=>source.Codice))
                .ForMember(dest => dest.NomeProdotto, opt => opt.MapFrom(source => source.Nome));

            CreateMap<CreaProdottoDto, Prodotto>()         
                .ForMember(dest => dest.NomeProdotto, opt => opt.MapFrom(source => source.Nome));

            CreateMap<AggiornaProdottoDTO, Prodotto>()
              .ForMember(dest => dest.NomeProdotto, opt => opt.MapFrom(source => source.Nome));

            CreateMap<EliminaProdottoDto, Prodotto>()
            .ForMember(dest => dest.IdProdotto, opt => opt.MapFrom(source => source.Codice));


        }

    }
}
