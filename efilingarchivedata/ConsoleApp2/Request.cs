namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            RequestCertifiedQuestions = new HashSet<RequestCertifiedQuestion>();
            RequestMiscMotions = new HashSet<RequestMiscMotion>();
            RequestNewCases = new HashSet<RequestNewCase>();
            RequestNoticeofAppearances = new HashSet<RequestNoticeofAppearance>();
            RequestOriginalCases = new HashSet<RequestOriginalCase>();
            Request1 = new HashSet<Request>();
            RequestDocuments = new HashSet<RequestDocument>();
            RequestEmails = new HashSet<RequestEmail>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestCertifiedQuestion> RequestCertifiedQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestMiscMotion> RequestMiscMotions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestNewCase> RequestNewCases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestNoticeofAppearance> RequestNoticeofAppearances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestOriginalCase> RequestOriginalCases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request1 { get; set; }

        public virtual Request Request2 { get; set; }

        public virtual RequestNoticeofAppearance RequestNoticeofAppearance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestDocument> RequestDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestEmail> RequestEmails { get; set; }
    }
}
