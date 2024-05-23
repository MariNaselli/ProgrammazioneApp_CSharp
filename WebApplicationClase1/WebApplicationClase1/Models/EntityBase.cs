using System;
using System.Data;

namespace WebApplicationClase1.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
