using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class BookingConfig : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> entity)
    {
        entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD6B73E10F");

        entity.ToTable("Booking");

        entity.HasIndex(e => e.GuestId, "idx_booking_guest");

        entity.HasIndex(e => e.RoomId, "idx_booking_room");

        entity.Property(e => e.BookingId).HasColumnName("BookingID");
        entity.Property(e => e.CheckIn).IsRequired().HasDefaultValueSql("(getdate())");
        entity.Property(e => e.CheckOut).IsRequired().HasDefaultValueSql("(getdate())");
        entity.Property(e => e.Confirmation).HasDefaultValue(false);
        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.GuestId)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("GuestID");
        entity.Property(e => e.RoomId).HasColumnName("RoomID").IsRequired(false);
        entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

        entity.HasOne(d => d.Guest).WithMany(p => p.Bookings)
            .HasForeignKey(d => d.GuestId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__Booking__GuestID__4CA06362");

        entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
            .HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK__Booking__RoomID__4D94879B");
    }
}
