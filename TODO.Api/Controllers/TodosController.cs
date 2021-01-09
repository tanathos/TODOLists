using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TODO.Api.Models;

namespace TODO.Api.Controllers
{
    [ApiController]
    public class TodosController : Controller
    {
        private readonly TodoContext _context;

        public TodosController(
            TodoContext context)
        {
            _context = context;
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetTodos() 
        {
            return Ok(await _context.Todos.ToListAsync());
        }
    }
}
