using System;
using System.Linq;

namespace BookProject.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
