using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwSpendingController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/VwSpending
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<VwSpending>>> GetVwSpendings()
        {
            return await _context.VwSpendings.ToListAsync();
        }   
    }
}
