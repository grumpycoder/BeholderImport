using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterMediaAudioVideoRelMap : EntityTypeConfiguration<ChapterMediaAudioVideoRel>
    {
        public ChapterMediaAudioVideoRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterMediaAudioVideoRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.MediaAudioVideoId).HasColumnName("MediaAudioVideoId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ChapterMediaAudioVideoRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterMediaAudioVideoRels)
                .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.MediaAudioVideo)
                .WithMany(t => t.ChapterMediaAudioVideoRels)
                .HasForeignKey(d => d.MediaAudioVideoId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterMediaAudioVideoRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ChapterMediaAudioVideoRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
