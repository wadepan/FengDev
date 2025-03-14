namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestEmail")]
    public partial class RequestEmail
    {
        public int RequestEmailID { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public int? RequestNoticeofAppearanceID { get; set; }

        public int? DocketRequestId { get; set; }

        public virtual Request Request { get; set; }

        public virtual RequestNoticeofAppearance RequestNoticeofAppearance { get; set; }
    }
}
