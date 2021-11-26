using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryNews.Models;
using LibraryNews.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppNewsRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NewsContext _context;

        public IndexModel(ILogger<IndexModel> logger, NewsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Article> news { get; set; }


        // public IEnumerable<Category> categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? searchTitle { get; set; }
        [BindProperty(SupportsGet = true)] 
        public int? selectCategory { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? selectCountry { get; set; }
        [BindProperty]
        public SelectList countryOptions { get; set; }
        public SelectList categoryOptions { get; set; }
        
        public Category categories { get; set; }
        public Country countries { get; set; }
     

        //get the news and filter
        public async Task OnGetAsync(string searchTitle,int selectCategory, string selectCountry)
        {
            categoryOptions = new SelectList(_context.Categories, nameof(categories.IdCategory), nameof(categories.Namecategory));
            countryOptions = new SelectList(_context.Countries, nameof(countries.CodeCountry), nameof(countries.Namecountry));


            news = await _context.Articles.Where(x => x.Visible == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchTitle))
            {
                news = await _context.Articles.Where(s => s.Title.Contains(searchTitle) && s.Visible == true).ToListAsync();
              
            }
    
            if (selectCategory != 0 && !string.IsNullOrEmpty(selectCountry))
            {
                news = await _context.Articles.Where((s => s.Idcategory == selectCategory && s.Idcountry==selectCountry &&(s.Visible == true)) ).ToListAsync();

            }
            else if (selectCategory != 0)
            {
                news = await _context.Articles.Where(s => s.Idcategory == selectCategory && s.Visible == true).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(selectCountry))
            {
                news = await _context.Articles.Where(s => s.Idcountry == selectCountry && s.Visible == true).ToListAsync();
            }

           
        }


       
    }
}
