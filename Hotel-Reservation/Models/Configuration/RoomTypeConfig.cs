using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Reservation.Models.Configuration;

public class RoomTypeConfig : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> entity)
    {
        entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8961188377F13");

        entity.ToTable("RoomType");

        entity.HasIndex(e => e.Name, "UQ__RoomType__737584F630B725BA").IsUnique();

        entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
        entity.Property(e => e.Description).HasColumnType("text");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}
