using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }
    }
}
