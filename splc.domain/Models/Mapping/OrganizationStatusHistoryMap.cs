using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationStatusHistoryMap : EntityTypeConfiguration<OrganizationStatusHistory>
    {
        public OrganizationStatusHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationStatusHistory", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
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
                .WithMany(t => t.OrganizationStatusHistories)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationStatusHistories)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.OrganizationStatusHistoriesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.OrganizationStatusHistoriesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.OrganizationStatusHistoriesModified)
                .HasForeignKey(d => d.ModifiedUserId);


        }
    }
}
