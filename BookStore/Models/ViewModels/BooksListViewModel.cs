using System.Collections.Generic;

namespace BookStore.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set;}
    }
}
