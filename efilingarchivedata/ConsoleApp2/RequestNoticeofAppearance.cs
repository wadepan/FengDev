namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestNoticeofAppearance")]
    public partial class RequestNoticeofAppearance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestNoticeofAppearance()
        {
            Requests = new HashSet<Request>();
            RequestEmails = new HashSet<RequestEmail>();
        }

        public int RequestNoticeofAppearanceID { get; set; }

        public int RequestID { get; set; }

        public bool isFilingforSolicitorGeneral { get; set; }

        public int PartyTypeID { get; set; }

        public int RequestAttorneyInfoID { get; set; }

        public int RequestAddressID { get; set; }

        public bool isCounselofRecord { get; set; }

        public bool isCJA { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public int FilerId { get; set; }

        public bool IsProSe { get; set; }

        public bool IsPublic { get; set; }

        public bool IsNotify { get; set; }

        public int? WithdrawRequestID { get; set; }

        public virtual Request Request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        public virtual RequestAddress RequestAddress { get; set; }

        public virtual RequestAttorneyInfo RequestAttorneyInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestEmail> RequestEmails { get; set; }
    }
}
