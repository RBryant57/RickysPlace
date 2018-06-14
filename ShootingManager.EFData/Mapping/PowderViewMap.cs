using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class PowderViewMap : EntityTypeConfiguration<PowderView>
    {
        public PowderViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Name, t.PowderName, t.ManufacturerId, t.ManufacturerName, t.ManufacturerAddress, t.ManufacturerCity, t.ManufacturerState, t.ManufacturerZip, t.ManufacturerURL, t.PowderTypeId, t.PowderTypeName, t.PowderShapeId, t.PowderShapeName });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PowderName)
                .IsRequired()
                .HasMaxLength(101);

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

            this.Property(t => t.PowderTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PowderTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PowderShapeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PowderShapeName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PowderView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PowderName).HasColumnName("PowderName");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
            this.Property(t => t.ManufacturerAddress).HasColumnName("ManufacturerAddress");
            this.Property(t => t.ManufacturerCity).HasColumnName("ManufacturerCity");
            this.Property(t => t.ManufacturerState).HasColumnName("ManufacturerState");
            this.Property(t => t.ManufacturerZip).HasColumnName("ManufacturerZip");
            this.Property(t => t.ManufacturerURL).HasColumnName("ManufacturerURL");
            this.Property(t => t.ManufacturerNotes).HasColumnName("ManufacturerNotes");
            this.Property(t => t.PowderTypeId).HasColumnName("PowderTypeId");
            this.Property(t => t.PowderTypeName).HasColumnName("PowderTypeName");
            this.Property(t => t.PowderTypeNotes).HasColumnName("PowderTypeNotes");
            this.Property(t => t.PowderShapeId).HasColumnName("PowderShapeId");
            this.Property(t => t.PowderShapeName).HasColumnName("PowderShapeName");
            this.Property(t => t.PowderShapeNotes).HasColumnName("PowderShapeNotes");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
