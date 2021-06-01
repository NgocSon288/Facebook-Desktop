using System;

namespace Facebook.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdateBy { get; set; }

        bool? Status { get; set; }
    }
}