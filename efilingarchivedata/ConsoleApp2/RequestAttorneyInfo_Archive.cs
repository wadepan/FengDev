namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestAttorneyInfo_Archive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestAttorneyInfo_Archive()
        {
            RequestNoticeofAppearance_Archive = new HashSet<RequestNoticeofAppearance_Archive>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestAttorneyInfoID { get; set; }

        [Required]
        [StringLength(750)]
        public string PartyName { get; set; }

        [StringLength(100)]
        public string FirmName { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        public int PrefixID { get; set; }

        public int? SuffixID { get; set; }

        [StringLength(250)]
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestNoticeofAppearance_Archive> RequestNoticeofAppearance_Archive { get; set; }
    }
}
