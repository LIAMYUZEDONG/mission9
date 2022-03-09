using Microsoft.AspNetCore.Mvc;
using BookProject.Models;
namespace BookProject.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket basketServices)
        {
            basket = basketServices;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}