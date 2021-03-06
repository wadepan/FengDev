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
    
    public partial class Provider
    {
        public Provider()
        {
            this.HomeInsurance = new HashSet<HomeInsurance>();
            this.LU_ServiceAgent = new HashSet<LU_ServiceAgent>();
            this.Activity = new HashSet<Activity>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ProviderTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
        public string CellPhone { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<HomeInsurance> HomeInsurance { get; set; }
        public virtual LU_ObjectAttribute ProviderType { get; set; }
        public virtual ICollection<LU_ServiceAgent> LU_ServiceAgent { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
