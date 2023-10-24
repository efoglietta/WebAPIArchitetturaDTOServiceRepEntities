using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ArchitetturaDTOEntities.DTO;
using ArchitetturaDTOEntities.Repository;
using ArchitetturaDTOEntities.Entities;
using ArchitetturaDTOEntities.Services;
using Microsoft.AspNetCore.Cors;

namespace ArchitetturaDTOEntities.Controllers
{
    // TIPI DI RESPONSE HTTP
    //  return Ok(prodotti); //200 ok, eventualmente con body response
    // return NotFound(); //404
    //  return BadRequest(); //400 bad request
    //   return NoContent(); //204  operazione ok ma content response vuoto
    //  return CreatedAtAction("nomeAction", new { id = prodotto.IdProdotto}, prodotto); //201 - Creato correttamente
    // return Problem("Entity set  is null.");  //restituisce  ObjectResult con un ProblemDetail con messaggio

    [EnableCors("Policy1")]
    //[EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiEntitiesController : ControllerBase
    {
        private IProdottiService _serviceProdotti;
        private IGenericProdottiService _serviceGenericProdotti;
        public ProdottiEntitiesController(IProdottiService serviceProdotti, IGenericProdottiService serviceGenericProdotti)
        => (_serviceProdotti, _serviceGenericProdotti) = (serviceProdotti, serviceGenericProdotti);
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Prodotto>> Get(int id)
        // public async Task<List<Prodotto>> GetAll()
        {
           // var p = await _serviceProdotti.RestituisciProdotto(id);
            // CON GENERIC REPOSITORY
            var p = await _serviceGenericProdotti.RestituisciProdotto(id);
            return p;
        }
            [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodotto>>> GetAll()
        // public async Task<List<Prodotto>> GetAll()
        {
            try
            {
                var prodotti = await _serviceProdotti.RestituisciProdotti();
                if (prodotti == null || prodotti.Count() == 0) return NotFound();
                return prodotti;
                // return Ok(prodotti);
            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpPost]
        public async Task<IActionResult> PostProdotto(Prodotto prodotto)
        {
            await _serviceProdotti.CreaProdotto(prodotto);
            return Ok(new { idInserito = prodotto.IdProdotto }); //restituisce info con id generato
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdotto(int id, Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return BadRequest("id non corrisponde al prodotto");
            }
            try
            {
             await   _serviceProdotti.AggiornaProdotto(prodotto);
                return Ok("Aggiornamento prodotto effettuato");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }







    }
}
