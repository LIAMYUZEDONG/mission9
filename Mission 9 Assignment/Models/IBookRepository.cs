using System;
using System.Linq;

namespace BookProject.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        
    } 
}
