using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class BookingServiceConfig : IEntityTypeConfiguration<BookingService>
{
    public void Configure(EntityTypeBuilder<BookingService> entity)
    {
        entity.HasKey(e => new { e.BookingId, e.ServiceId }).HasName("PK__BookingS__CFC4A1C33CAB8E58");

        entity.ToTable("BookingService");

        entity.Property(e => e.BookingId).HasColumnName("BookingID");
        entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        entity.Property(e => e.Quantity).HasDefaultValue(1);

        entity.HasOne(d => d.Booking).WithMany(p => p.BookingServices)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__BookingSe__Booki__5441852A");

        entity.HasOne(d => d.Service).WithMany(p => p.BookingServices)
            .HasForeignKey(d => d.ServiceId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__BookingSe__Servi__5535A963");
    }
}
