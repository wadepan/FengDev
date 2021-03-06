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
    
    public partial class Lease
    {
        public Lease()
        {
            this.LU_LeaseDoc = new HashSet<LU_LeaseDoc>();
            this.Renter = new HashSet<Renter>();
        }
    
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<LU_LeaseDoc> LU_LeaseDoc { get; set; }
        public virtual ICollection<Renter> Renter { get; set; }
        public virtual RProperty RProperty { get; set; }
    }
}
