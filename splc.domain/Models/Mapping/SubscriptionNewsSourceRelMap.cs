using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class SubscriptionNewsSourceRelMap : EntityTypeConfiguration<SubscriptionNewsSourceRel>
    {
        public SubscriptionNewsSourceRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SubscriptionNewsSourceRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SubscriptionId).HasColumnName("SubscriptionId");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.SubscriptionNewsSourceRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.NewsSource)
                .WithMany(t => t.SubscriptionNewsSourceRels)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.SubscriptionNewsSourceRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.SubscriptionNewsSourceRels)
                .HasForeignKey(d => d.SubscriptionId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.SubscriptionNewsSourceRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
