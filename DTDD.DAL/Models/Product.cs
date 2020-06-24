﻿using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            Comment = new HashSet<Comment>();
            OrderDetail = new HashSet<OrderDetail>();
            SalePhones = new HashSet<SalePhones>();
        }

        public int Id { get; set; }
        public int IdCat { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Memory { get; set; }
        public string Os { get; set; }
        public string CpuSpeed { get; set; }
        public string CameraPrimary { get; set; }
        public string Battery { get; set; }
        public string Bluetooth { get; set; }
        public string Wlan { get; set; }
        public string PromotionPrice { get; set; }
       

        public virtual Category IdCatNavigation { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<SalePhones> SalePhones { get; set; }
    }
}
