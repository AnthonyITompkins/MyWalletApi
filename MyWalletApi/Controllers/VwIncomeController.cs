using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWalletApi.Models;

namespace MyWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwIncomeController(TompkinsContext context) : ControllerBase
    {
        private readonly TompkinsContext _context = context;

        // GET: api/VwIncome
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<VwIncome>>> GetVwIncomes()
        {
            return await _context.VwIncomes.ToListAsync();
        }
    }
}
