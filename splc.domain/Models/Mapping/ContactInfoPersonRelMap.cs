using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ContactInfoPersonRelMap : EntityTypeConfiguration<ContactInfoPersonRel>
    {
        public ContactInfoPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContactInfoPersonRel", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.ContactInfoId).HasColumnName("ContactId");
            this.Property(t => t.ContactInfoTypeId).HasColumnName("ContactTypeId");
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
            this.HasRequired(t => t.ContactInfo)
                .WithMany(t => t.ContactInfoPersonRels)
                .HasForeignKey(d => d.ContactInfoId);
            this.HasRequired(t => t.CommonPerson)
                .WithMany(t => t.ContactInfoPersonRels)
                .HasForeignKey(t => t.PersonId);
            this.HasRequired(t => t.ContactInfoType)
                .WithMany(t => t.ContactInfoPersonRels)
                .HasForeignKey(d => d.ContactInfoTypeId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ContactInfoPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);

            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ContactInfoPersonRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ContactInfoPersonRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ContactInfoPersonRelsModified)
            .HasForeignKey(d => d.ModifiedUserId);


        }
    }
}
