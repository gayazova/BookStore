using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenre = new HashSet<BookGenre>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<BookGenre> BookGenre { get; set; }
    }
}
