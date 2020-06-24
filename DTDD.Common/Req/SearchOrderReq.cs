using System;
using System.Collections.Generic;
using System.Text;

namespace DTDD.Common.Req
{
    public class SearchOrderReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int OrderId { get; set; }
        public string Type { get; set; }
        public string Keyword { get; set; }
    }
}