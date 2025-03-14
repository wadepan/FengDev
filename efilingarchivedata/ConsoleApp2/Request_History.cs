namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request_History
    {
        [Key]
        public int triggerId { get; set; }

        public DateTime triggerDate { get; set; }

        public int? triggerBy { get; set; }

        [Required]
        [StringLength(10)]
        public string triggerAction { get; set; }

        public int RequestID { get; set; }

        public int FilingTypeID { get; set; }

        public int CaseTypeID { get; set; }

        public int RequestStatusID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? ReviewedDate { get; set; }

        public int? ReviewedBy { get; set; }

        public int? DocketRequestId { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public int? RequestNoticeofAppearanceID { get; set; }

        public int? PaymentTypeId { get; set; }

        public bool? IsCheckReceived { get; set; }

        [StringLength(2200)]
        public string sText { get; set; }

        [StringLength(2500)]
        public string Notes { get; set; }
    }
}
