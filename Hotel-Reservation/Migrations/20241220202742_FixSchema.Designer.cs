﻿// <auto-generated />
using System;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20241220202742_FixSchema")]
    partial class FixSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel_Reservation.Models.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AmenityID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AmenityId")
                        .HasName("PK__Amenity__842AF52B46CBF827");

                    b.HasIndex(new[] { "Name" }, "UQ__Amenity__737584F6D2C221E3")
                        .IsUnique();

                    b.ToTable("Amenity", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Billing", b =>
                {
                    b.Property<int>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BillingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("BillingId")
                        .HasName("PK__Billing__F1656D1398813D48");

                    b.HasIndex("BookingId");

                    b.ToTable("Billing", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateOnly>("CheckIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateOnly>("CheckOut")
                        .HasColumnType("date");

                    b.Property<bool?>("Confirmation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("GuestId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("GuestID");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("BookingId")
                        .HasName("PK__Booking__73951ACD6B73E10F");

                    b.HasIndex(new[] { "GuestId" }, "idx_booking_guest");

                    b.HasIndex(new[] { "RoomId" }, "idx_booking_room");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.BookingService", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("BookingId", "ServiceId")
                        .HasName("PK__BookingS__CFC4A1C33CAB8E58");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookingService", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Guest", b =>
                {
                    b.Property<string>("Ssn")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("SSN");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("F_Name");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("L_Name");

                    b.HasKey("Ssn")
                        .HasName("PK__Guest__CA1E8E3DC2762DAD");

                    b.HasIndex(new[] { "Email" }, "UQ__Guest__A9D10534748FE658")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "idx_guest_email");

                    b.ToTable("Guest", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RoomTypeID");

                    b.HasKey("RoomId")
                        .HasName("PK__Room__3286391910FC43A5");

                    b.HasIndex("RoomTypeId");

                    b.HasIndex(new[] { "RoomNumber" }, "UQ__Room__AE10E07A64546856")
                        .IsUnique();

                    b.HasIndex(new[] { "RoomNumber" }, "idx_room_number");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int")
                        .HasColumnName("AmenityID");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("RoomId", "AmenityId")
                        .HasName("PK__RoomAmen__9AC4964B05865F64");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenity", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("RoomTypeId")
                        .HasName("PK__RoomType__BCC8961188377F13");

                    b.HasIndex(new[] { "Name" }, "UQ__RoomType__737584F630B725BA")
                        .IsUnique();

                    b.ToTable("RoomType", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ServiceId")
                        .HasName("PK__Service__C51BB0EAAC884D5A");

                    b.HasIndex(new[] { "Name" }, "UQ__Service__737584F6A64FF3CE")
                        .IsUnique();

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Billing", b =>
                {
                    b.HasOne("Hotel_Reservation.Models.Booking", "Booking")
                        .WithMany("Billings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Billing__Booking__59063A47");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Booking", b =>
                {
                    b.HasOne("Hotel_Reservation.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Booking__GuestID__4CA06362");

                    b.HasOne("Hotel_Reservation.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Booking__RoomID__4D94879B");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.BookingService", b =>
                {
                    b.HasOne("Hotel_Reservation.Models.Booking", "Booking")
                        .WithMany("BookingServices")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BookingSe__Booki__5441852A");

                    b.HasOne("Hotel_Reservation.Models.Service", "Service")
                        .WithMany("BookingServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BookingSe__Servi__5535A963");

                    b.Navigation("Booking");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Room", b =>
                {
                    b.HasOne("Hotel_Reservation.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Room__RoomTypeID__3F466844");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.RoomAmenity", b =>
                {
                    b.HasOne("Hotel_Reservation.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__RoomAmeni__Ameni__46E78A0C");

                    b.HasOne("Hotel_Reservation.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__RoomAmeni__RoomI__45F365D3");

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Booking", b =>
                {
                    b.Navigation("Billings");

                    b.Navigation("BookingServices");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Guest", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel_Reservation.Models.Service", b =>
                {
                    b.Navigation("BookingServices");
                });
#pragma warning restore 612, 618
        }
    }
}
