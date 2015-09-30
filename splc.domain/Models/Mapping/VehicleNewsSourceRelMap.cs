//using System.Data.Entity.ModelConfiguration;

//namespace splc.domain.Models.Mapping
//{
//    public class VehicleNewsSourceRelMap : EntityTypeConfiguration<VehicleNewsSourceRel>
//    {
//        public VehicleNewsSourceRelMap()
//        {
//            // Primary Key
//            this.HasKey(t => t.Id);

//            // Properties
//            // Table & Column Mappings
//            this.ToTable("VehicleNewsSourceRel", "Beholder");
//            this.Property(t => t.Id).HasColumnName("Id");
//            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
//            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
//            this.Property(t => t.DateStart).HasColumnName("DateStart");
//            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
//            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
//            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
//            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

//            // Relationships
//            this.HasOptional(t => t.ApprovalStatus)
//                .WithMany(t => t.VehicleNewsSourceRels)
//                .HasForeignKey(d => d.ApprovalStatusId);
//            this.HasRequired(t => t.NewsSource)
//                .WithMany(t => t.VehicleNewsSourceRels)
//                .HasForeignKey(d => d.NewsSourceId);
//            this.HasRequired(t => t.RelationshipType)
//                .WithMany(t => t.VehicleNewsSourceRels)
//                .HasForeignKey(d => d.RelationshipTypeId);
//            this.HasRequired(t => t.Vehicle)
//                .WithMany(t => t.VehicleNewsSourceRels)
//                .HasForeignKey(d => d.VehicleId);
//            this.HasOptional(t => t.PrimaryStatu)
//                .WithMany(t => t.VehicleNewsSourceRels)
//                .HasForeignKey(d => d.PrimaryStatusId);

//        }
//    }
//}
