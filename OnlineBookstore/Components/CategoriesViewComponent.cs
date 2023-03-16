using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookProjectRepository repo { get; set; }

        public CategoriesViewComponent(IBookProjectRepository temp)
        {
            repo = temp;
        }

        // pulls data for category display
        public IViewComponentResult Invoke()
        {
            // selects which category I'm on
            ViewBag.SelectedType = RouteData?.Values["categoryType"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }


    }
}
