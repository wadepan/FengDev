namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestEmail_Archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual Request_Archive Request_Archive { get; set; }
    }
}
