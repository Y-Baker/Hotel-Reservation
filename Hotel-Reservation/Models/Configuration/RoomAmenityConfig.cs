using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class RoomAmenityConfig : IEntityTypeConfiguration<RoomAmenity>
{
    public void Configure(EntityTypeBuilder<RoomAmenity> entity)
    {
        entity.HasKey(e => new { e.RoomId, e.AmenityId }).HasName("PK__RoomAmen__9AC4964B05865F64");

        entity.ToTable("RoomAmenity");

        entity.Property(e => e.RoomId).HasColumnName("RoomID");
        entity.Property(e => e.AmenityId).HasColumnName("AmenityID");
        entity.Property(e => e.Quantity).HasDefaultValue(1);

        entity.HasOne(d => d.Amenity).WithMany(p => p.RoomAmenities)
            .HasForeignKey(d => d.AmenityId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__RoomAmeni__Ameni__46E78A0C");

        entity.HasOne(d => d.Room).WithMany(p => p.RoomAmenities)
            .HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__RoomAmeni__RoomI__45F365D3");
    }
}
