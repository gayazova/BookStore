using System;

namespace BookStore.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public Basket Basket { get; set; }
        public Employee Employee { get; set; }
    }
}
