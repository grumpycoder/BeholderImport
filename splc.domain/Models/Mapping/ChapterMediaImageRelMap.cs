using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterMediaImageRelMap : EntityTypeConfiguration<ChapterMediaImageRel>
    {
        public ChapterMediaImageRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterMediaImageRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.MediaImageId).HasColumnName("MediaImageId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ChapterMediaImageRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterMediaImageRels)
                .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.MediaImage)
                .WithMany(t => t.ChapterMediaImageRels)
                .HasForeignKey(d => d.MediaImageId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterMediaImageRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasOptional(t => t.RelationshipType)
                .WithMany(t => t.ChapterMediaImageRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
