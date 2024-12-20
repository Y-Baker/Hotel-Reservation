using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class ServiceConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> entity)
    {
        entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EAAC884D5A");

        entity.ToTable("Service");

        entity.HasIndex(e => e.Name, "UQ__Service__737584F6A64FF3CE").IsUnique();

        entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        entity.Property(e => e.Description).HasColumnType("text");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
    }
}
