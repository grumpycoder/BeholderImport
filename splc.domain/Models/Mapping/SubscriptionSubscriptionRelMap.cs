using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class SubscriptionSubscriptionRelMap : EntityTypeConfiguration<SubscriptionSubscriptionRel>
    {
        public SubscriptionSubscriptionRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SubscriptionSubscriptionRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SubscriptionId).HasColumnName("SubscriptionId");
            this.Property(t => t.Subscription2Id).HasColumnName("Subscription2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.SubscriptionSubscriptionRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.SubscriptionSubscriptionRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.SubscriptionSubscriptionRels)
                .HasForeignKey(d => d.SubscriptionId);
            this.HasRequired(t => t.Subscription2)
                .WithMany(t => t.SubscriptionSubscriptionRels2)
                .HasForeignKey(d => d.Subscription2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.SubscriptionSubscriptionRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
