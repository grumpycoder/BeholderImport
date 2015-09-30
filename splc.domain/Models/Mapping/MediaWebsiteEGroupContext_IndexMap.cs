using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaWebsiteEGroupContext_IndexMap : EntityTypeConfiguration<MediaWebsiteEGroupContext_Index>
    {
        public MediaWebsiteEGroupContext_IndexMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("v_MediaWebsiteEGroupContext", "Beholder");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContextText).HasColumnName("ContextText");


            this.Property(t => t.MediaWebsiteEGroupId).HasColumnName("MediaWebsiteEGroupId");

          

        }
    }
}
