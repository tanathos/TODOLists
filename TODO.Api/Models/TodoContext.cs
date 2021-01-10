using Microsoft.EntityFrameworkCore;
using System;

namespace TODO.Api.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todos.db;");
        }
    }
}
