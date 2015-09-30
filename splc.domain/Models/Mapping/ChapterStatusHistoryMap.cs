using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterStatusHistoryMap : EntityTypeConfiguration<ChapterStatusHistory>
    {
        public ChapterStatusHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterStatusHistory", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            this.Property(t => t.ReportStatusFlag).HasColumnName("ReportStatusFlag");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.ActiveStatus)
                .WithMany(t => t.ChapterStatusHistories)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterStatusHistories)
                .HasForeignKey(d => d.ChapterId);

            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.ChapterStatusHistoriesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ChapterStatusHistoriesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ChapterStatusHistoriesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
