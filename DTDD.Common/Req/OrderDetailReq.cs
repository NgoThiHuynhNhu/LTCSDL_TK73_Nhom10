using System;
using System.Collections.Generic;
using System.Text;

namespace DTDD.Common.Req
{
    public class OrderDetailReq
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Price { get; set; }
        public int SaleQuantity { get; set; }
    }
}
