using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class BillingConfig : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> entity)
    {
        entity.HasKey(e => e.BillingId).HasName("PK__Billing__F1656D1398813D48");

        entity.ToTable("Billing");

        entity.Property(e => e.BillingId).HasColumnName("BillingID");
        entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
        entity.Property(e => e.BookingId).HasColumnName("BookingID").IsRequired(false);
        entity.Property(e => e.PaymentDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasOne(d => d.Booking).WithMany(p => p.Billings)
            .HasForeignKey(d => d.BookingId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK__Billing__Booking__59063A47");
    }
}
