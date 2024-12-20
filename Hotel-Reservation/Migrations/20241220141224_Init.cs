using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Amenity__842AF52B46CBF827", x => x.AmenityID);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    F_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    L_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guest__CA1E8E3DC2762DAD", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomType__BCC8961188377F13", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Service__C51BB0EAAC884D5A", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__3286391910FC43A5", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK__Room__RoomTypeID__3F466844",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Confirmation = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Booking__73951ACD6B73E10F", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK__Booking__GuestID__4CA06362",
                        column: x => x.GuestID,
                        principalTable: "Guest",
                        principalColumn: "SSN");
                    table.ForeignKey(
                        name: "FK__Booking__RoomID__4D94879B",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    AmenityID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomAmen__9AC4964B05865F64", x => new { x.RoomID, x.AmenityID });
                    table.ForeignKey(
                        name: "FK__RoomAmeni__Ameni__46E78A0C",
                        column: x => x.AmenityID,
                        principalTable: "Amenity",
                        principalColumn: "AmenityID");
                    table.ForeignKey(
                        name: "FK__RoomAmeni__RoomI__45F365D3",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    BillingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Billing__F1656D1398813D48", x => x.BillingID);
                    table.ForeignKey(
                        name: "FK__Billing__Booking__59063A47",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "BookingService",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookingS__CFC4A1C33CAB8E58", x => new { x.BookingID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK__BookingSe__Booki__5441852A",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__BookingSe__Servi__5535A963",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Amenity__737584F6D2C221E3",
                table: "Amenity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Billing_BookingID",
                table: "Billing",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "idx_booking_guest",
                table: "Booking",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "idx_booking_room",
                table: "Booking",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingService_ServiceID",
                table: "BookingService",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "idx_guest_email",
                table: "Guest",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "UQ__Guest__A9D10534748FE658",
                table: "Guest",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_room_number",
                table: "Room",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeID",
                table: "Room",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Room__AE10E07A64546856",
                table: "Room",
                column: "RoomNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "UQ__RoomType__737584F630B725BA",
                table: "RoomType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Service__737584F6A64FF3CE",
                table: "Service",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "BookingService");

            migrationBuilder.DropTable(
                name: "RoomAmenity");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
