using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp2
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Request_Archive> Request_Archive { get; set; }
        public virtual DbSet<Request_History> Request_History { get; set; }
        public virtual DbSet<RequestAddress> RequestAddresses { get; set; }
        public virtual DbSet<RequestAddress_Archive> RequestAddress_Archive { get; set; }
        public virtual DbSet<RequestAttorneyInfo> RequestAttorneyInfoes { get; set; }
        public virtual DbSet<RequestAttorneyInfo_Archive> RequestAttorneyInfo_Archive { get; set; }
        public virtual DbSet<RequestCertifiedQuestion> RequestCertifiedQuestions { get; set; }
        public virtual DbSet<RequestDocument> RequestDocuments { get; set; }
        public virtual DbSet<RequestDocument_Archive> RequestDocument_Archive { get; set; }
        public virtual DbSet<RequestEmail> RequestEmails { get; set; }
        public virtual DbSet<RequestEmail_Archive> RequestEmail_Archive { get; set; }
        public virtual DbSet<RequestMiscMotion> RequestMiscMotions { get; set; }
        public virtual DbSet<RequestMiscMotion_Archive> RequestMiscMotion_Archive { get; set; }
        public virtual DbSet<RequestNewCase> RequestNewCases { get; set; }
        public virtual DbSet<RequestNewCase_Archive> RequestNewCase_Archive { get; set; }
        public virtual DbSet<RequestNoticeofAppearance> RequestNoticeofAppearances { get; set; }
        public virtual DbSet<RequestNoticeofAppearance_Archive> RequestNoticeofAppearance_Archive { get; set; }
        public virtual DbSet<RequestOriginalCase> RequestOriginalCases { get; set; }
        public virtual DbSet<RequestOriginalCase_Archive> RequestOriginalCase_Archive { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestCertifiedQuestions)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestMiscMotions)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestNewCases)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestNoticeofAppearances)
                .WithRequired(e => e.Request)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestOriginalCases)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.Request1)
                .WithOptional(e => e.Request2)
                .HasForeignKey(e => e.DocketRequestId);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestDocuments)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestEmails)
                .WithOptional(e => e.Request)
                .HasForeignKey(e => e.DocketRequestId);

            modelBuilder.Entity<Request_Archive>()
                .HasMany(e => e.RequestMiscMotion_Archive)
                .WithRequired(e => e.Request_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request_Archive>()
                .HasMany(e => e.RequestNewCase_Archive)
                .WithRequired(e => e.Request_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request_Archive>()
                .HasMany(e => e.RequestNoticeofAppearance_Archive)
                .WithRequired(e => e.Request_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request_Archive>()
                .HasMany(e => e.RequestOriginalCase_Archive)
                .WithRequired(e => e.Request_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request_Archive>()
                .HasMany(e => e.RequestEmail_Archive)
                .WithOptional(e => e.Request_Archive)
                .HasForeignKey(e => e.DocketRequestId);

            modelBuilder.Entity<Request_History>()
                .Property(e => e.triggerAction)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAddress>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<RequestAddress>()
                .HasMany(e => e.RequestNoticeofAppearances)
                .WithRequired(e => e.RequestAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestAddress_Archive>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<RequestAddress_Archive>()
                .HasMany(e => e.RequestNoticeofAppearance_Archive)
                .WithRequired(e => e.RequestAddress_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestAttorneyInfo>()
                .HasMany(e => e.RequestNoticeofAppearances)
                .WithRequired(e => e.RequestAttorneyInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestAttorneyInfo_Archive>()
                .HasMany(e => e.RequestNoticeofAppearance_Archive)
                .WithRequired(e => e.RequestAttorneyInfo_Archive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestNewCase>()
                .Property(e => e.StateTerritory)
                .IsFixedLength();

            modelBuilder.Entity<RequestNewCase_Archive>()
                .Property(e => e.StateTerritory)
                .IsFixedLength();

            modelBuilder.Entity<RequestNoticeofAppearance>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.RequestNoticeofAppearance)
                .HasForeignKey(e => e.RequestNoticeofAppearanceID);
        }
    }
}
