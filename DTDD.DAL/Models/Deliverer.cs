using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Deliverer
    {
        public Deliverer()
        {
            Order = new HashSet<Order>();
        }

        public int DelivererId { get; set; }
        public string DelivererName { get; set; }
        public string DelivererPhone { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
