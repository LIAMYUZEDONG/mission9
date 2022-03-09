using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookProject.Models
{
    public class EFCartRepository : ICartRepository


    {
        private BookContext context;

        public EFCartRepository (BookContext temp)
        {
            context = temp;
        }
        public IQueryable<Cart> Cart { get => context.Carts.Include(x => x.Lines).ThenInclude(x => x.Book); set => context.Carts.Include(x => x.Lines).ThenInclude(x => x.Book); }

        public void SaveCart(Cart cart)
        {
            context.AttachRange(cart.Lines.Select(x => x.Book));


            if (cart.CartId == 0)
            {
                context.Carts.Add(cart);
            }

            context.SaveChanges();
        }
    }
}
