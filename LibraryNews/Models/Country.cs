using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryNews.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
        }

        public string CodeCountry { get; set; }
        public string Namecountry { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
