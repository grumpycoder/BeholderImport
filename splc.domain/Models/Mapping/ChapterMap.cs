using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterMap : EntityTypeConfiguration<Chapter>
    {
        public ChapterMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.ChapterName)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.ChapterDesc)
                .HasMaxLength(256);

            Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Chapter", "Beholder");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ChapterName).HasColumnName("ChapterName");
            Property(t => t.ChapterDesc).HasColumnName("ChapterDesc");
//            Property(t => t.ChapterTypeId).HasColumnName("ChapterTypeId");
            Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            Property(t => t.ReportStatusFlag).HasColumnName("ReportStatusFlag");
            Property(t => t.FormedDate).HasColumnName("FormedDate");
            Property(t => t.DisbandDate).HasColumnName("DisbandDate");
            Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            Property(t => t.IsHeadquarters).HasColumnName("IsHeadquarters");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            Property(t => t.DateModified).HasColumnName("DateModified");
            Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            HasRequired(t => t.ActiveStatus)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.ActiveStatusId);
            HasRequired(t => t.ApprovalStatus)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.ApprovalStatusId);
//            HasOptional(t => t.ChapterType)
//                .WithMany(t => t.Chapters)
//                .HasForeignKey(d => d.ChapterTypeId);
            HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            HasOptional(t => t.MovementClass)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.MovementClassId);
            HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.RemovalStatusId);
            HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ChaptersCreated)
                .HasForeignKey(d => d.CreatedUserId);
            HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ChaptersDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ChaptersModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
