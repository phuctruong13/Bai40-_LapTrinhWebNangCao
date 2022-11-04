using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogAPI.Models
{
    public class Tag : BaseEntity
    {
        public String name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; } // 1 tag có nhiều article
    }
}