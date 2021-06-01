using System;

namespace Facebook.Model.Abstract
{
    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdateBy { get; set; }

        public bool? Status { get; set; }
    }
}