using System;

namespace TODO.Api.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Title { get; set; }
    }
}
