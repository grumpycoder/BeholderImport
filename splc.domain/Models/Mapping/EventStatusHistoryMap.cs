using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventStatusHistoryMap : EntityTypeConfiguration<EventStatusHistory>
    {
        public EventStatusHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventStatusHistory", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            this.Property(t => t.ReportStatusFlag).HasColumnName("ReportStatusFlag");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.ActiveStatus)
                .WithMany(t => t.EventStatusHistories)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventStatusHistories)
                .HasForeignKey(d => d.EventId);

            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.EventStatusHistoriesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.EventStatusHistoriesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.EventStatusHistoriesModified)
                .HasForeignKey(d => d.ModifiedUserId);


        }
    }
}
