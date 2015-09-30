using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PublicationName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Subscription", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderIdOld).HasColumnName("OrderIdOld");
            this.Property(t => t.PublicationName).HasColumnName("PublicationName");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.RenewalPermissionDate).HasColumnName("RenewalPermissionDate");
            this.Property(t => t.SubscriptionRate).HasColumnName("SubscriptionRate");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasOptional(t => t.ActiveStatus)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.SubscriptionsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.SubscriptionsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.SubscriptionsModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
