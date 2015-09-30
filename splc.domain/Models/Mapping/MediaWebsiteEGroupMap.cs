using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaWebsiteEGroupMap : EntityTypeConfiguration<MediaWebsiteEGroup>
    {
        public MediaWebsiteEGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.URL)
                .HasMaxLength(255);

            this.Property(t => t.IPAddress)
                .HasMaxLength(20);

            this.Property(t => t.ActiveYear); 

            this.Property(t => t.WhoIsInfo)
                .HasMaxLength(4000);

            this.Property(t => t.Summary)
                .HasMaxLength(4000);

            this.Property(t => t.City)
                .HasMaxLength(40);

            this.Property(t => t.County)
                .HasMaxLength(40);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MediaWebsiteEGroup", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.WebsiteEGroupTypeId).HasColumnName("WebsiteEGroupTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.DateDiscovered).HasColumnName("DateDiscovered");
            this.Property(t => t.DatePublished).HasColumnName("DatePublished");
            this.Property(t => t.DateOffline).HasColumnName("DateOffline");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.ActiveYear).HasColumnName("ActiveYear");
            this.Property(t => t.ActiveStatusId).HasColumnName("ActiveStatusId");
            this.Property(t => t.IsReported).HasColumnName("IsReported");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.WhoIsInfo).HasColumnName("WhoIsInfo");
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
            this.Property(t => t.MediaWebsiteEGroupContextId).HasColumnName("MediaWebsiteEGroupContextId");

            // Relationships
            this.HasOptional(t => t.ActiveStatus)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.ActiveStatusId);
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.ConfidentialityType)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasRequired(t => t.MediaType)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.NewsSource)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.StateId);
            this.HasOptional(t => t.WebsiteGroupType)
                .WithMany(t => t.MediaWebsiteEGroups)
                .HasForeignKey(d => d.WebsiteEGroupTypeId);

            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.MediaWebsiteEGroupsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaWebsiteEGroupsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaWebsiteEGroupsModified)
                .HasForeignKey(d => d.ModifiedUserId);

            //this.HasOptional(t => t.MediaWebsiteEGroupContext)
            //    .WithMany(t => t.MediaWebsiteEGroups)
            //    .HasForeignKey(d => d.MediaWebsiteEGroupContextId);

            //this.HasOptional(t => t.MediaWebsiteEGroupContext_Index)
            //    .WithMany(t => t.MediaWebsiteEGroups)
            //    .HasForeignKey(d => d.MediaWebsiteEGroupContextId);


        }
    }
}
