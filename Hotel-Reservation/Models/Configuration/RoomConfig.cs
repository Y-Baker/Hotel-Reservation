using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class RoomConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> entity)
    {
        entity.HasKey(e => e.RoomId).HasName("PK__Room__3286391910FC43A5");

        entity.ToTable("Room");

        entity.HasIndex(e => e.RoomNumber, "UQ__Room__AE10E07A64546856").IsUnique();

        entity.HasIndex(e => e.RoomNumber, "idx_room_number");

        entity.Property(e => e.RoomId).HasColumnName("RoomID");
        entity.Property(e => e.Availability).HasDefaultValue(true);
        entity.Property(e => e.Description).HasColumnType("text");
        entity.Property(e => e.Location)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.PricePerNight).HasColumnType("decimal(10, 2)");
        entity.Property(e => e.RoomNumber)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);
        entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID").IsRequired(false);

        entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
            .HasForeignKey(d => d.RoomTypeId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK__Room__RoomTypeID__3F466844");
    }
}
