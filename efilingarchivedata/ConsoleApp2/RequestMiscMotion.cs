namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestMiscMotion")]
    public partial class RequestMiscMotion
    {
        public int RequestMiscMotionID { get; set; }

        public int RequestID { get; set; }

        public bool isPetitioneretal { get; set; }

        public bool isRespondentetal { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        [Required]
        [StringLength(250)]
        public string PetitionerLastName { get; set; }

        [StringLength(250)]
        public string PetitionerFirstName { get; set; }

        [StringLength(250)]
        public string RespondentLastName { get; set; }

        [StringLength(250)]
        public string RespondentFirstName { get; set; }

        public virtual Request Request { get; set; }
    }
}
