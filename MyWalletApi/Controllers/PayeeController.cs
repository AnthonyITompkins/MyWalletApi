using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeeController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/Payee
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Payee>>> GetPayees()
        {
            return await _context.Payees.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Payee>> GetPayee(int id)
        {
            var payee = await _context.Payees.FindAsync(id);
            if (payee == null)
            {
                return NotFound();
            }
            return payee;
        }

        [HttpPost]
        [Route("{payee}")]
        public async Task<ActionResult<Payee>> PostPayee(Payee payee)
        {
            _context.Payees.Add(payee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPayee", new { id = payee.PayeeId }, payee);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutPayee(int id, Payee payee)
        {
            if (id != payee.PayeeId)
            {
                return BadRequest();
            }
            _context.Entry(payee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayeeExists(id))
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

        private bool PayeeExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePayee(int id)
        {
            var payee = await _context.Payees.FindAsync(id);
            if (payee == null)
            {
                return NotFound();
            }
            _context.Payees.Remove(payee);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}
