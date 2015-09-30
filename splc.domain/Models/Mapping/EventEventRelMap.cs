using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventEventRelMap : EntityTypeConfiguration<EventEventRel>
    {
        public EventEventRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventEventRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.Event2Id).HasColumnName("Event2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.EventEventRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventEventRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.Event2)
                .WithMany(t => t.EventEventRels2)
                .HasForeignKey(d => d.Event2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.EventEventRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.EventEventRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
