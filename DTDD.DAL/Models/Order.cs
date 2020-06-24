using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int DelivererId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Deliverer Deliverer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
