using ArchitetturaDTOEntities.DTO;
using ArchitetturaDTOEntities.Entities;
using ArchitetturaDTOEntities.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArchitetturaDTOEntities.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiDTOController : ControllerBase
    {
       
        private IProdottiServiceDTO _serviceProdottiDTO;
        public ProdottiDTOController(IProdottiServiceDTO serviceProdottiDTO) 
            => _serviceProdottiDTO = serviceProdottiDTO;

        [HttpPost]
        public async Task<IActionResult> PostProdotto(CreaProdottoDto creaProdottoDto)
        {
            
         int id=   await _serviceProdottiDTO.CreaProdotto(creaProdottoDto);
            return Ok(new {codice=id}); //restituisce info con id generato
        }

    }
}
