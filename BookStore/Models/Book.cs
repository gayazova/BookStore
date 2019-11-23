using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthor = new HashSet<BookAuthor>();
            BookGenre = new HashSet<BookGenre>();
            Good = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string PublishingHouse { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
        public ICollection<Good> Good { get; set; }
    }
}
