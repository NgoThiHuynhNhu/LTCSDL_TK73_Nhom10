using System;
using System.Collections.Generic;

namespace DTDD.DAL.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int PhoneId { get; set; }
        public string Fullname { get; set; }
        public DateTime CommentTime { get; set; }
        public string CommentContent { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Product Phone { get; set; }
    }
}
