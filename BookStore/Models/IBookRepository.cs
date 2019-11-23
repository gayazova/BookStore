using System.Collections.Generic;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
    }
}
