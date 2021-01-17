using System;

namespace TODO.Api.Models
{
    public class Todo
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
