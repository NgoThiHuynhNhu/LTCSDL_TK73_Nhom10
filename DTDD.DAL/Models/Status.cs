using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
