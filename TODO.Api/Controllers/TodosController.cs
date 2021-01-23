using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        [ProducesResponseType(typeof(List<Todo>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTodos(bool all = false) 
        {
            IQueryable<Todo> query = _context.Todos;

            if (!all) 
            {
                query = query.Where(w => w.Done == false);
            }

            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
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
            _todo.Description = todo.Description;
            _todo.CreatedDate = DateTime.Now;
            _todo.UpdatedDate = DateTime.Now;

            _context.Todos.Add(_todo);

            await _context.SaveChangesAsync();

            return Ok(new CreatedTodoResponse() { Id = new Guid(_todo.Id) });
        }

        [HttpPut("{id}/done")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Done([FromRoute] Guid id) 
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(f => f.Id == id.ToString());

            if (todo != null)
            {
                todo.Done = true;

                await _context.SaveChangesAsync();

                return Ok();
            }
            else 
            {
                return NotFound();
            }
        }
    }
}
