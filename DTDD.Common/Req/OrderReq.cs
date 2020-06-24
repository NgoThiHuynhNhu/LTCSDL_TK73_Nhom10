using System;
using System.Collections.Generic;
using System.Text;

namespace DTDD.Common.Req
{
    public class OrderReq
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int DelivererId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public string Note { get; set; }
    }
}