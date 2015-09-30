using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class AddressSubscriptionsRelMap : EntityTypeConfiguration<AddressSubscriptionsRel>
    {
        public AddressSubscriptionsRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AddressSubscriptionsRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SubscriptionsId).HasColumnName("SubscriptionsId");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            this.Property(t => t.FirstKnownUseDate).HasColumnName("FirstKnownUseDate");
            this.Property(t => t.LastKnownUseDate).HasColumnName("LastKnownUseDate");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany(t => t.AddressSubscriptionsRels)
                .HasForeignKey(d => d.AddressId);
            this.HasRequired(t => t.AddressType)
                .WithMany(t => t.AddressSubscriptionsRels)
                .HasForeignKey(d => d.AddressTypeId);
            this.HasRequired(t => t.PrimaryStatus)
                .WithMany(t => t.AddressSubscriptionsRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.AddressSubscriptionsRels)
                .HasForeignKey(d => d.SubscriptionsId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.AddressSubscriptionsRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.AddressSubscriptionsRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.AddressSubscriptionsRelsModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
