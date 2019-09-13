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
    
    public partial class HOA
    {
        public int Id { get; set; }
        public Nullable<int> PropertyID { get; set; }
        public Nullable<bool> IsPrimary { get; set; }
        public string HOAName { get; set; }
        public Nullable<decimal> HOAAnnualFee { get; set; }
        public string HOAManagmentCompany { get; set; }
        public string HOAPhone { get; set; }
        public string HOAEmail { get; set; }
        public string HOAWebsite { get; set; }
        public string HOALoginAccount { get; set; }
        public string HOALoginPwdHint { get; set; }
        public string HOABoardMeetingSchedule { get; set; }
        public string Comments { get; set; }
    
        public virtual RProperty RProperty { get; set; }
    }
}