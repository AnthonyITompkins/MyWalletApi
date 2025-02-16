using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrxImportController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/TrxImport 
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TrxImport>>> GetTrxImports()
        {
            return await _context.TrxImports.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TrxImport>> GetTrxImport(int id)
        {
            var trx = await _context.TrxImports.FindAsync(id);
            if (trx == null)
            {
                return NotFound();
            }
            return trx;
        }

        [HttpPost]
        public async Task<ActionResult<TrxImport>> PostTrx(TrxImport trx)
        {
            _context.TrxImports.Add(trx);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTrxImport", new { id = trx.TrxImportId }, trx);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutTrxImport(int id, TrxImport trx)
        {
            if (id != trx.TrxImportId)
            {
                return BadRequest();
            }
            _context.Entry(trx).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrxImportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private bool TrxImportExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTrxImport(int id)
        {
            var trx = await _context.TrxImports.FindAsync(id);
            if (trx == null)
            {
                return NotFound();
            }
            _context.TrxImports.Remove(trx);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
