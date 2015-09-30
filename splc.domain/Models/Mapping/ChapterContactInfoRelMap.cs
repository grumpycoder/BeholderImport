using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterContactInfoRelMap : EntityTypeConfiguration<ChapterContactInfoRel>
    {
        public ChapterContactInfoRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterContactInfoRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
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
                .WithMany(t => t.ChapterContactInfoRels)
                .HasForeignKey(d => d.ContactInfoId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterContactInfoRels)
                .HasForeignKey(t => t.ChapterId);
            this.HasRequired(t => t.ContactInfoType)
                .WithMany(t => t.ChapterContactInfoRels)
                .HasForeignKey(d => d.ContactInfoTypeId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterContactInfoRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ChapterContactInfoRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ChapterContactInfoRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ChapterContactInfoRelsModified)
            .HasForeignKey(d => d.ModifiedUserId);


        }
    }
}
