using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class PrimerViewMap : EntityTypeConfiguration<PrimerView>
    {
        public PrimerViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Name, t.PrimerFullName, t.PrimerName, t.PrimerTypeId, t.PrimerTypeName, t.PrimerTypeAbbreviation, t.ManufacturerId, t.ManufacturerName, t.ManufacturerAddress, t.ManufacturerCity, t.ManufacturerState, t.ManufacturerZip, t.ManufacturerURL });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PrimerFullName)
                .IsRequired()
                .HasMaxLength(101);

            this.Property(t => t.PrimerName)
                .IsRequired()
                .HasMaxLength(101);

            this.Property(t => t.PrimerTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PrimerTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PrimerTypeAbbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManufacturerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ManufacturerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManufacturerAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManufacturerCity)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManufacturerState)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ManufacturerZip)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.ManufacturerURL)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("PrimerView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PrimerFullName).HasColumnName("PrimerFullName");
            this.Property(t => t.PrimerName).HasColumnName("PrimerName");
            this.Property(t => t.PrimerTypeId).HasColumnName("PrimerTypeId");
            this.Property(t => t.PrimerTypeName).HasColumnName("PrimerTypeName");
            this.Property(t => t.PrimerTypeAbbreviation).HasColumnName("PrimerTypeAbbreviation");
            this.Property(t => t.PrimerTypeNotes).HasColumnName("PrimerTypeNotes");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
            this.Property(t => t.ManufacturerAddress).HasColumnName("ManufacturerAddress");
            this.Property(t => t.ManufacturerCity).HasColumnName("ManufacturerCity");
            this.Property(t => t.ManufacturerState).HasColumnName("ManufacturerState");
            this.Property(t => t.ManufacturerZip).HasColumnName("ManufacturerZip");
            this.Property(t => t.ManufacturerURL).HasColumnName("ManufacturerURL");
            this.Property(t => t.ManufacturerNotes).HasColumnName("ManufacturerNotes");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
