using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaImageSubscriptionRelMap : EntityTypeConfiguration<MediaImageSubscriptionRel>
    {
        public MediaImageSubscriptionRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaImageSubscriptionRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaImageId).HasColumnName("MediaImageId");
            this.Property(t => t.SubscriptionId).HasColumnName("SubscriptionId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaImageSubscriptionRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaImage)
                .WithMany(t => t.MediaImageSubscriptionRels)
                .HasForeignKey(d => d.MediaImageId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaImageSubscriptionRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaImageSubscriptionRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.MediaImageSubscriptionRels)
                .HasForeignKey(d => d.SubscriptionId);

        }
    }
}
