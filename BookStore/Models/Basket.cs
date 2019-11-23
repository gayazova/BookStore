using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Basket
    {
        public Basket()
        {
            Good = new HashSet<Good>();
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<Good> Good { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
    }
}
