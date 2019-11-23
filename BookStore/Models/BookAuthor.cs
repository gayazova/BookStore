using System;

namespace BookStore.Models
{
    public partial class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
