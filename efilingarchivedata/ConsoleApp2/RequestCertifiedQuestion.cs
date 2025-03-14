namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestCertifiedQuestion")]
    public partial class RequestCertifiedQuestion
    {
        [Key]
        public int RequestCertQID { get; set; }

        public int RequestID { get; set; }

        public int OriginateCourtID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public virtual Request Request { get; set; }
    }
}
