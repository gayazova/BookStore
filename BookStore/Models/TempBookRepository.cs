using System.Collections.Generic;

namespace BookStore.Models
{
    public class TempBookRepository : IBookRepository
    {
        public IEnumerable<Book> Books => new BookStoreContext().Book;
    }
}
