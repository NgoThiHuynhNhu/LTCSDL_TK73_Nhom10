using System;
using System.Collections.Generic;
using System.Text;

namespace DTDD.Common.Req
{
    public class CategoryReq
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
    }
}
