using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Models;
using OnlineBookstore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookProjectRepository repo;
        public HomeController(IBookProjectRepository temp) => repo = temp;

        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            int pageSize = 10;

            //this is how we pass multiple things into the index page so we can access both the db and pagination info
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p=> p.Category == categoryType || categoryType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                    (categoryType == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == categoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            }; 
            
            return View(x);
        }


           
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
