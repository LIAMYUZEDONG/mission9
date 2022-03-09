using System;
using System.Linq;

namespace BookProject.Models
{
    public interface ICartRepository
    {
        IQueryable<Cart>Cart { get; set; }

        void SaveCart(Cart cart);
    }
}
