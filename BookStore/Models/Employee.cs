using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomic { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public ICollection<Purchase> Purchase { get; set; }
    }
}
