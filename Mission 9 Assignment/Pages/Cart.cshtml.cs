using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookProject.Infrastructure;
using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookProject.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository repo { get; set;}

        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }



        public CartModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

  

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? " /";
 
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(p, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
