using System;

namespace BookStore.Models
{
    public partial class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
