//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageMe.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issue
    {
        public Issue()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public int IssueId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ReportedAt { get; set; }
        public Nullable<int> ReportedBy { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> ResolvedDate { get; set; }
        public int PropertyId { get; set; }
    
        public virtual Renter Renter { get; set; }
        public virtual RProperty RProperty { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual LU_ObjectAttribute IssueStatus { get; set; }
    }
}
