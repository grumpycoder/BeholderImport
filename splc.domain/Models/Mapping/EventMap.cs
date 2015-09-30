using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EventName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Religion)
                .HasMaxLength(20);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Event", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventName).HasColumnName("EventName");
            this.Property(t => t.EventDate).HasColumnName("EventDate");
            this.Property(t => t.EventDocumentationTypeId).HasColumnName("EventDocumentationTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            this.Property(t => t.ReportStatusFlag).HasColumnName("ReportStatusFlag");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.Religion).HasColumnName("Religion");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.WebIncidentTypeId).HasColumnName("WebIncidentTypeId");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.ActiveStatus)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasRequired(t => t.ApprovalStatus)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.EventsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.EventsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.EventsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasOptional(t => t.EventDocumentationType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.EventDocumentationTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.WebIncidentType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.WebIncidentTypeId);
            this.HasOptional(t => t.NewsSource)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.NewsSourceId);

        }
    }
}
