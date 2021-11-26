using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryNews.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public int IdCategory { get; set; }
        public string Namecategory { get; set; }

        public virtual ICollection<Article> Articles { get; set; }


    }
}
