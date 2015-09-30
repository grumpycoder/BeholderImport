using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class AddressPersonRelMap : EntityTypeConfiguration<AddressPersonRel>
    {
        public AddressPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AddressPersonRel", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
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
                .WithMany(t => t.AddressPersonRels)
                .HasForeignKey(d => d.AddressId);
            this.HasOptional(t => t.AddressType)
                .WithMany(t => t.AddressPersonRels)
                .HasForeignKey(d => d.AddressTypeId);

            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.AddressPersonRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.AddressPersonRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.AddressPersonRelsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasRequired(t => t.CommonPerson)
                .WithMany(t => t.AddressPersonRels)
                .HasForeignKey(d => d.PersonId);
            this.HasRequired(t => t.PrimaryStatus)
                .WithMany(t => t.AddressPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
