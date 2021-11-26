using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryNews.Models
{
    public partial class Article
    {
        public int IdAritcle { get; set; }
        public int Idsource { get; set; }
        public int Idcategory { get; set; }
        public string Idcountry { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ArticleUrl { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        public virtual Category IdcategoryNavigation { get; set; }
        public virtual Country IdcountryNavigation { get; set; }
        public virtual Source IdsourceNavigation { get; set; }
    }
}
