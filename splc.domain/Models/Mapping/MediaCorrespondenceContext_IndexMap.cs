using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceContext_IndexMap : EntityTypeConfiguration<MediaCorrespondenceContext_Index>
    {
        public MediaCorrespondenceContext_IndexMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("v_MediaCorrespondenceContext", "Beholder");

            this.Property(t => t.Id).HasColumnName("Id");
            //this.Property(t => t.MimeTypeId).HasColumnName("MimeTypeId");
            //this.Property(t => t.DocumentExtension).HasColumnName("DocumentExtension");
            //this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContextText).HasColumnName("ContextText");

            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");


        }
    }
}
