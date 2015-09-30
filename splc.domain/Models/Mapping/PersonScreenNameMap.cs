using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PersonScreenNameMap : EntityTypeConfiguration<PersonScreenName>
    {
        public PersonScreenNameMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ScreenName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UsedAt)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PersonScreenName", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BeholderPersonId).HasColumnName("PersonId");
            this.Property(t => t.ScreenName).HasColumnName("ScreenName");
            this.Property(t => t.UsedAt).HasColumnName("UsedAt");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");
            this.Property(t => t.FirstKnownUseDate).HasColumnName("FirstKnownUseDate");
            this.Property(t => t.LastKnownUseDate).HasColumnName("LastKnownUseDate");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            //this.Property(t => t.Comments).HasColumnName("Comments");

            // Relationships
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.PersonScreenNames)
                .HasForeignKey(d => d.BeholderPersonId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.PersonScreenNames)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.PersonScreenNamesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.PersonScreenNamesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.PersonScreenNamesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
