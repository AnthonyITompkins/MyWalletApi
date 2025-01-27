using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/Account
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        [HttpPost]
        [Route("{account}")]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }
            _context.Entry(account).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AccountExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
