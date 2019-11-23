using System;

namespace BookStore.Models
{
    public partial class Good
    {
        public int BookId { get; set; }
        public int BasketId { get; set; }
        public int Number { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public Basket Basket { get; set; }
        public Book Book { get; set; }
    }
}
