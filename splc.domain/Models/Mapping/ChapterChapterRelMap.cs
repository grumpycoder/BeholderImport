using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterChapterRelMap : EntityTypeConfiguration<ChapterChapterRel>
    {
        public ChapterChapterRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterChapterRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.Chapter2Id).HasColumnName("Chapter2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ChapterChapterRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterChapterRels)
                .HasForeignKey(d => d.ChapterId);
            //this.HasRequired(t => t.Chapter1)
            //    .WithMany(t => t.ChapterChapterRels1)
            //    .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.Chapter2)
                .WithMany(t => t.ChapterChapterRels2)
                .HasForeignKey(d => d.Chapter2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterChapterRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ChapterChapterRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
