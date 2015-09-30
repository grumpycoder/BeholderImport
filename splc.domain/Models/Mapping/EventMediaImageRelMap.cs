using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventMediaImageRelMap : EntityTypeConfiguration<EventMediaImageRel>
    {
        public EventMediaImageRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventMediaImageRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.MediaImageId).HasColumnName("MediaImageId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventMediaImageRels)
                .HasForeignKey(d => d.EventId);

            this.HasRequired(t => t.MediaImage)
                .WithMany(t => t.EventMediaImageRels)
                .HasForeignKey(d => d.MediaImageId);

            this.HasOptional(t => t.RelationshipType)
                .WithMany(t => t.EventMediaImageRels)
                .HasForeignKey(d => d.RelationshipTypeId);

            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.EventMediaImageRels)
                .HasForeignKey(d => d.ApprovalStatusId);

            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.EventMediaImageRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
