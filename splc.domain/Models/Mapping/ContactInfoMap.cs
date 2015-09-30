using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ContactInfoMap : EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Contact)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.Extension)
                .HasMaxLength(5);

            // Table & Column Mappings
            ToTable("ContactInfo", "Common");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Contact).HasColumnName("Contact");
            Property(t => t.Extension).HasColumnName("Extension");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            Property(t => t.DateModified).HasColumnName("DateModified");
            Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ContactInfoCreated)
                .HasForeignKey(d => d.CreatedUserId);
            HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ContactInfoDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ContactInfoModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
