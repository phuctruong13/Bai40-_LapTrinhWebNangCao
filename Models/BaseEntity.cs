using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogAPI.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}