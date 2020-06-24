using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
