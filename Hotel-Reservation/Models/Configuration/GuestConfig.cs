using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class GuestConfig : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> entity)
    {
        entity.HasKey(e => e.Ssn).HasName("PK__Guest__CA1E8E3DC2762DAD");

        entity.ToTable("Guest");

        entity.HasIndex(e => e.Email, "UQ__Guest__A9D10534748FE658").IsUnique();

        entity.HasIndex(e => e.Email, "idx_guest_email");

        entity.Property(e => e.Ssn)
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("SSN");
        entity.Property(e => e.Address)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.ContactNumber)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.FName)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("F_Name");
        entity.Property(e => e.LName)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("L_Name");
    }
}
