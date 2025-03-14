namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request_Archive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request_Archive()
        {
            RequestMiscMotion_Archive = new HashSet<RequestMiscMotion_Archive>();
            RequestNewCase_Archive = new HashSet<RequestNewCase_Archive>();
            RequestNoticeofAppearance_Archive = new HashSet<RequestNoticeofAppearance_Archive>();
            RequestOriginalCase_Archive = new HashSet<RequestOriginalCase_Archive>();
            RequestEmail_Archive = new HashSet<RequestEmail_Archive>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public DateTime DateArchived { get; set; }

        public int ArchivedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestMiscMotion_Archive> RequestMiscMotion_Archive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestNewCase_Archive> RequestNewCase_Archive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestNoticeofAppearance_Archive> RequestNoticeofAppearance_Archive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestOriginalCase_Archive> RequestOriginalCase_Archive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestEmail_Archive> RequestEmail_Archive { get; set; }
    }
}
