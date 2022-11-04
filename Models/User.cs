using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogAPI.Models
{
    public class User : BaseEntity
    {
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }

        public ICollection<Article> Articles { get; set; } // 1 user có nhiều Article

        public ICollection<Comment> Comments { get; set; } // 1 user có nhiều comment
        public ICollection<Category> Categories { get; set; } // 1 user có nhiều category

        public ICollection<ArticleLiker> ArticleLikers {get;set;}
    }
}