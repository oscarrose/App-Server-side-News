using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryNews.Data;
using LibraryNews.Models;

namespace AppNewsMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly NewsContext _context;

        public ArticlesController(NewsContext context)
        {
            _context = context;
        }

       
        // GET: Articles
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["Idcategory"] = new SelectList(_context.Categories, "IdCategory", "Namecategory");
            ViewData["Idcountry"] = new SelectList(_context.Countries, "CodeCountry", "Namecountry");
            ViewData["Idsource"] = new SelectList(_context.Sources, "IdSource", "Namesource");

            var newsContext = _context.Articles.Include(a => a.IdcategoryNavigation).Include(a => a.IdcountryNavigation).Include(a => a.IdsourceNavigation);

            if (!(String.IsNullOrEmpty(searchString)))
            {
               var newsContext2= _context.Articles.Where(x => x.Title.Contains(searchString));
                return View(await newsContext2.ToListAsync());

            }
        
            return View(await newsContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.IdcategoryNavigation)
                .Include(a => a.IdcountryNavigation)
                .Include(a => a.IdsourceNavigation)
                .FirstOrDefaultAsync(m => m.IdAritcle == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["Idcategory"] = new SelectList(_context.Categories, "IdCategory", "Namecategory");
            ViewData["Idcountry"] = new SelectList(_context.Countries, "CodeCountry", "Namecountry");
            ViewData["Idsource"] = new SelectList(_context.Sources, "IdSource", "Namesource");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAritcle,Idsource,Idcategory,Idcountry,Title,Description,ImageUrl,ArticleUrl,DateCreate,PublicationDate,Author,Visible")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategory"] = new SelectList(_context.Categories, "IdCategory", "Namecategory");
            ViewData["Idcountry"] = new SelectList(_context.Countries, "CodeCountry", "Namecountry");
            ViewData["Idsource"] = new SelectList(_context.Sources, "IdSource", "Namesource");
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["Idcategory"] = new SelectList(_context.Categories, "IdCategory", "Namecategory");
            ViewData["Idcountry"] = new SelectList(_context.Countries, "CodeCountry", "Namecountry");
            ViewData["Idsource"] = new SelectList(_context.Sources, "IdSource", "Namesource");
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAritcle,Idsource,Idcategory,Idcountry,Title,Description,ImageUrl,ArticleUrl,DateCreate,PublicationDate,Author,Visible")] Article article)
        {
            if (id != article.IdAritcle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.IdAritcle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategory"] = new SelectList(_context.Categories, "IdCategory", "Namecategory");
            ViewData["Idcountry"] = new SelectList(_context.Countries, "CodeCountry", "Namecountry");
            ViewData["Idsource"] = new SelectList(_context.Sources, "IdSource", "Namesource");
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.IdcategoryNavigation)
                .Include(a => a.IdcountryNavigation)
                .Include(a => a.IdsourceNavigation)
                .FirstOrDefaultAsync(m => m.IdAritcle == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.IdAritcle == id);
        }
    }
}
