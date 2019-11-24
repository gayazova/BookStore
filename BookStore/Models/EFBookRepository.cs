using System.Collections.Generic;

namespace BookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private readonly BookStoreContext context;
        public EFBookRepository(BookStoreContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Book> Books => context.Book;
    }
}
