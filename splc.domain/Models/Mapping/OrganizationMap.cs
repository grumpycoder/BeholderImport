using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OrganizationName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OrganizationDesc)
                .HasMaxLength(256);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Organization", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationTypeId).HasColumnName("OrganizationTypeId");
            this.Property(t => t.OrganizationName).HasColumnName("OrganizationName");
            this.Property(t => t.OrganizationDesc).HasColumnName("OrganizationDesc");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            this.Property(t => t.ReportStatusFlag).HasColumnName("ReportStatusFlag");
            this.Property(t => t.FormedDate).HasColumnName("FormedDate");
            this.Property(t => t.DisbandDate).HasColumnName("DisbandDate");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.ActiveStatus)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasRequired(t => t.ApprovalStatus)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasRequired(t => t.OrganizationType)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.OrganizationTypeId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.OrganizationsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.OrganizationsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.OrganizationsModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
