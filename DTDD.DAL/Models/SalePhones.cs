using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class SalePhones
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Product Phone { get; set; }
    }
}
