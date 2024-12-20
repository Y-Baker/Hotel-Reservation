using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class AmenityConfig : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> entity)
    {
        entity.HasKey(e => e.AmenityId).HasName("PK__Amenity__842AF52B46CBF827");

        entity.ToTable("Amenity");

        entity.HasIndex(e => e.Name, "UQ__Amenity__737584F6D2C221E3").IsUnique();

        entity.Property(e => e.AmenityId).HasColumnName("AmenityID");
        entity.Property(e => e.Description).HasColumnType("text");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}

