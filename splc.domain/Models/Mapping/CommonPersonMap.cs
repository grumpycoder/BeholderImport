using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class CommonPersonMap : EntityTypeConfiguration<CommonPerson>
    {
        public CommonPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SSN)
                .IsFixedLength()
                .HasMaxLength(9);

            this.Property(t => t.FName)
                .HasMaxLength(256);

            this.Property(t => t.MName)
                .HasMaxLength(256);

            this.Property(t => t.LName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.DriversLicenseNumber)
                .HasMaxLength(125);

            this.Property(t => t.Height)
                .HasMaxLength(20);

            this.Property(t => t.Weight)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Person", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SSN).HasColumnName("SSN");
            this.Property(t => t.PrefixId).HasColumnName("PrefixId");
            this.Property(t => t.FName).HasColumnName("FName");
            this.Property(t => t.MName).HasColumnName("MName");
            this.Property(t => t.LName).HasColumnName("LName");
            this.Property(t => t.SuffixId).HasColumnName("SuffixId");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.ActualDOBIndicator).HasColumnName("ActualDOBIndicator");
            this.Property(t => t.GenderId).HasColumnName("GenderId");
            this.Property(t => t.LicenseTypeId).HasColumnName("LicenseTypeId");
            this.Property(t => t.DriversLicenseNumber).HasColumnName("DriversLicenseNumber");
            this.Property(t => t.DriversLicenseStateId).HasColumnName("DriversLicenseStateId");
            this.Property(t => t.DeceasedDate).HasColumnName("DeceasedDate");
            this.Property(t => t.ActualDeceasedDateIndicator).HasColumnName("ActualDeceasedDateIndicator");
            this.Property(t => t.HairColorId).HasColumnName("HairColorId");
            this.Property(t => t.HairPatternId).HasColumnName("HairPatternId");
            this.Property(t => t.EyeColorId).HasColumnName("EyeColorId");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.RaceId).HasColumnName("RaceId");
            this.Property(t => t.MaritialStatusId).HasColumnName("MartialStatusId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            //this.Property(t => t.OldId).HasColumnName("OldId");

            // Relationships
            this.HasOptional(t => t.MaritialStatus)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.MaritialStatusId);
            this.HasOptional(t => t.EyeColor)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.EyeColorId);
            this.HasOptional(t => t.Gender)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.GenderId);
            this.HasOptional(t => t.HairColor)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.HairColorId);
            this.HasOptional(t => t.HairPattern)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.HairPatternId);
            this.HasOptional(t => t.LicenseType)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.LicenseTypeId);
            //this.HasOptional(t => t.Prefix)
            //    .WithMany(t => t.CommonPerson)
            //    .HasForeignKey(d => d.PrefixId);
            this.HasOptional(t => t.Race)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.RaceId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.DriversLicenseStateId);
            this.HasOptional(t => t.Suffix)
                .WithMany(t => t.CommonPersons)
                .HasForeignKey(d => d.SuffixId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.CommonPersonsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.CommonPersonsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.CommonPersonsModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
