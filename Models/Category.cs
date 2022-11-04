using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogAPI.Models
{
    public class Category : BaseEntity
    {
        public String name { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy  { get; set; }
        public ICollection<Article> Articles { get; set; } // 1 category có nhiều article
    }
}