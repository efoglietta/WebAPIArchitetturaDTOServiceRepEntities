using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchitetturaDTOEntities.DataAccess;
using ArchitetturaDTOEntities.Entities;

namespace ArchitetturaDTOEntities.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottoesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProdottoesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Prodottoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodotto>>> GetProdotti()
        {
          if (_context.Prodotti == null)
          {
              return NotFound();
          }
            return await _context.Prodotti.ToListAsync();
        }

        // GET: api/Prodottoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodotto>> GetProdotto(int id)
        {
          if (_context.Prodotti == null)
          {
              return NotFound();
          }
            var prodotto = await _context.Prodotti.FindAsync(id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return prodotto;
        }

        // PUT: api/Prodottoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdotto(int id, Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return BadRequest();
            }

            _context.Entry(prodotto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdottoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //204 -  operazione ok ma content response vuoto
            return NoContent();
        }

        // POST: api/Prodottoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prodotto>> PostProdotto(Prodotto prodotto)
        {
          if (_context.Prodotti == null)
          {
                //restituisce  ObjectResult con un ProblemDetail con messaggio
              return Problem("Entity set 'NorthwindContext.Prodotti'  is null.");
          }
            _context.Prodotti.Add(prodotto);
            await _context.SaveChangesAsync();
            //201 - Creato correttamente
            return CreatedAtAction("GetProdotto", new { id = prodotto.IdProdotto }, prodotto);
        }

        // DELETE: api/Prodottoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdotto(int id)
        {
            if (_context.Prodotti == null)
            {
                return NotFound();
            }
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }

            _context.Prodotti.Remove(prodotto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdottoExists(int id)
        {
            return (_context.Prodotti?.Any(e => e.IdProdotto == id)).GetValueOrDefault();
        }
    }
}
