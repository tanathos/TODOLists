using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TODO.Api.Models;
using TODO.Api.ViewModels;

namespace TODO.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoContext _context;

        public TodosController(
            TodoContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTodos() 
        {
            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodos(Guid id)
        {
            return Ok(await _context.Todos.FirstOrDefaultAsync(f => f.Id == id.ToString()));
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(CreatedTodoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateTodoRequest todo) 
        {
            Todo _todo = new Todo();
            _todo.Id = Guid.NewGuid().ToString();
            _todo.Title = todo.Title;
            _todo.CreatedDate = DateTime.Now;
            _todo.UpdatedDate = DateTime.Now;

            _context.Todos.Add(_todo);

            await _context.SaveChangesAsync();

            return Ok(new CreatedTodoResponse() { Id = new Guid(_todo.Id) });
        }
    }
}
