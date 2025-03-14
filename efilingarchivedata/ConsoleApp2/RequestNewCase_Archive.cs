namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestNewCase_Archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestNewCaseID { get; set; }

        public int RequestID { get; set; }

        public int? OriginateCourtID { get; set; }

        public int? CourtofAppealsID { get; set; }

        public int? DistrictCourtID { get; set; }

        [StringLength(250)]
        public string CaseNumbers { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CourtofAppealDecisionDate { get; set; }

        public bool IsLowerCourtRehearingDenied { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AppealRehearingDeniedDate { get; set; }

        public bool IsCapitalCase { get; set; }

        public bool IsCapitalCaseDateSet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExecutionScheduledDate { get; set; }

        public bool IsFilingIFP { get; set; }

        public bool IsFilingVeteran { get; set; }

        public bool IsRule11 { get; set; }

        public bool IsRule124 { get; set; }

        public bool isPetitioneretal { get; set; }

        public bool isRespondentetal { get; set; }

        public DateTime? NoticeofAppealDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        [StringLength(2)]
        public string StateTerritory { get; set; }

        [Required]
        [StringLength(250)]
        public string PetitionerLastName { get; set; }

        [StringLength(250)]
        public string PetitionerFirstName { get; set; }

        [StringLength(250)]
        public string RespondentLastName { get; set; }

        [StringLength(250)]
        public string RespondentFirstName { get; set; }

        public virtual Request_Archive Request_Archive { get; set; }
    }
}
