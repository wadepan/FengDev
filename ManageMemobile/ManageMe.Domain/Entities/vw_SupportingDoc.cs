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
    
    public partial class vw_SupportingDoc
    {
        public System.Guid stream_id { get; set; }
        public byte[] file_stream { get; set; }
        public string name { get; set; }
        public bool is_directory { get; set; }
        public string unc_path { get; set; }
    }
}