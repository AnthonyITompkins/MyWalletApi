using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrxSplitController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/TrxSplit
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TrxSplit>>> GetTrxSplits()
        {
            return await _context.TrxSplits.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TrxSplit>> GetTrxSplit(int id)
        {
            var trxSplit = await _context.TrxSplits.FindAsync(id);
            if (trxSplit == null)
            {
                return NotFound();
            }
            return trxSplit;
        }

        [HttpPost]
        public async Task<ActionResult<TrxSplit>> PostTrxSplit(TrxSplit trxSplit)
        {
            _context.TrxSplits.Add(trxSplit);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTrxSplit", new { id = trxSplit.SplitId }, trxSplit);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutTrxSplit(int id, TrxSplit trxSplit)
        {
            if (id != trxSplit.SplitId)
            {
                return BadRequest();
            }
            _context.Entry(trxSplit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrxSplitExists(id))
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTrxSplit(int id)
        {
            var trxSplit = await _context.TrxSplits.FindAsync(id);
            if (trxSplit == null)
            {
                return NotFound();
            }
            _context.TrxSplits.Remove(trxSplit);
            await _context.SaveChangesAsync();
            return NoContent();
        }   

        private bool TrxSplitExists(int id)
        {
            return _context.TrxSplits.Any(e => e.SplitId == id);
        }   
    }
}
