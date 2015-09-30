using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Address1)
                .HasMaxLength(256);

            this.Property(t => t.Address2)
                .HasMaxLength(256);

            this.Property(t => t.City)
                .HasMaxLength(256);

            this.Property(t => t.County)
                .HasMaxLength(256);

            this.Property(t => t.Country)
                .HasMaxLength(256);

            this.Property(t => t.Zip5)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.Zip4)
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("Address", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.Zip5).HasColumnName("Zip5");
            this.Property(t => t.Zip4).HasColumnName("Zip4");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.AddressesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.AddressesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.AddressesModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.StateId);

        }
    }
}
