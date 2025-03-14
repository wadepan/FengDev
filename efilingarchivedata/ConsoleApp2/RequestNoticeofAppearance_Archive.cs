namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestNoticeofAppearance_Archive
    {
        [Key]
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

        public virtual Request_Archive Request_Archive { get; set; }

        public virtual RequestAddress_Archive RequestAddress_Archive { get; set; }

        public virtual RequestAttorneyInfo_Archive RequestAttorneyInfo_Archive { get; set; }
    }
}
