using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryNews.Models
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        public int IdSource { get; set; }
        public string Namesource { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
