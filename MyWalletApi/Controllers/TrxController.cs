using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrxController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/Trx 
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Trx>>> GetTrxs()
        {
            return await _context.Trxes.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Trx>> GetTrx(int id)
        {
            var trx = await _context.Trxes.FindAsync(id);
            if (trx == null)
            {
                return NotFound();
            }
            return trx;
        }   

        [HttpPost]
        public async Task<ActionResult<Trx>> PostTrx(Trx trx)
        {
            _context.Trxes.Add(trx);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTrx", new { id = trx.TrxId }, trx);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutTrx(int id, Trx trx)
        {
            if (id != trx.TrxId)
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
                if (!TrxExists(id))
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

        private bool TrxExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTrx(int id)
        {
            var trx = await _context.Trxes.FindAsync(id);
            if (trx == null)
            {
                return NotFound();
            }
            _context.Trxes.Remove(trx);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}
