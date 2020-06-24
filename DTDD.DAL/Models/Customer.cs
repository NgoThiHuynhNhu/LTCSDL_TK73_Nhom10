using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
