using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceMap : EntityTypeConfiguration<MediaCorrespondence>
    {
        public MediaCorrespondenceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CorrespondenceName)
                .HasMaxLength(100);

            this.Property(t => t.ToName)
                .HasMaxLength(80);

            this.Property(t => t.FromName)
                .HasMaxLength(80);

            this.Property(t => t.RenewalPermission)
                .HasMaxLength(500);

            this.Property(t => t.Summary)
                .HasMaxLength(4000);

            this.Property(t => t.City)
                .HasMaxLength(40);

            this.Property(t => t.County)
                .HasMaxLength(40);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            //this.MapToStoredProcedures(s =>
            //    s.Insert(i => i.HasName("Beholder.p_addMediaCorrespondence"))
            //     .Update(u => u.HasName("Beholder.p_updMediaCorrespondence")));

            // Table & Column Mappings
            this.ToTable("MediaCorrespondence", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.CorrespondenceTypeId).HasColumnName("CorrespondenceTypeId");
            this.Property(t => t.CorrespondenceName).HasColumnName("CorrespondenceName");
            this.Property(t => t.DateReceived).HasColumnName("DateReceived");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.ToName).HasColumnName("ToName");
            this.Property(t => t.FromName).HasColumnName("FromName");
            this.Property(t => t.DateRenewalPermission).HasColumnName("DateRenewalPermission");
            this.Property(t => t.RenewalPermissionTypeId).HasColumnName("RenewalPermissionTypeId");
            this.Property(t => t.RenewalPermission).HasColumnName("RenewalPermission");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            this.Property(t => t.MediaCorrespondenceContextId).HasColumnName("MediaCorrespondenceContextId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");

            // Relationships
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.MediaCorrespondencesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaCorrespondencesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaCorrespondencesModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasRequired(t => t.ConfidentialityType)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.CorrespondenceType)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.CorrespondenceTypeId);
            this.HasOptional(t => t.MediaType)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.RenewalPermmisionType)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.RenewalPermissionTypeId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.MediaCorrespondences)
                .HasForeignKey(d => d.StateId);

            //this.HasOptional(t => t.MediaCorrespondenceContext_Index)
            //    .WithMany(t => t.MediaCorrespondences)
            //    .HasForeignKey(d => d.MediaCorrespondenceContextId);

        }
    }
}
