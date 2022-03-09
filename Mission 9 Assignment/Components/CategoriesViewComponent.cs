using System;
using System.Linq;
using BookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
      private IBookRepository repo { get; set; }

      public CategoriesViewComponent (IBookRepository temp)
        {
            repo = temp;
        }



        public IViewComponentResult Invoke()
        {

            ViewBag.SelectCategory = RouteData?.Values["Category"];
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);


            return View(types);
        }
    }
}
