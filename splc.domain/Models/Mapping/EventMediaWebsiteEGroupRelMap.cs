using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventMediaWebsiteEGroupRelMap : EntityTypeConfiguration<EventMediaWebsiteEGroupRel>
    {
        public EventMediaWebsiteEGroupRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventMediaWebsiteEGroupRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.MediaWebsiteEGroupId).HasColumnName("MediaWebsiteEGroupId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.EventMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.MediaWebsiteEGroup)
                .WithMany(t => t.EventMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaWebsiteEGroupId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.EventMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.EventMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
