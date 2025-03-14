namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestDocument_Archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestDocID { get; set; }

        public int RequestID { get; set; }

        [Required]
        [StringLength(500)]
        public string DocUName { get; set; }

        [Required]
        [StringLength(500)]
        public string DocOName { get; set; }

        public int DocSeqNo { get; set; }

        public int ListDocumentID { get; set; }

        public int DocumentStatusID { get; set; }

        public bool isDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public bool isPublic { get; set; }

        public DateTime DateArchived { get; set; }

        public int ArchivedBy { get; set; }
    }
}
