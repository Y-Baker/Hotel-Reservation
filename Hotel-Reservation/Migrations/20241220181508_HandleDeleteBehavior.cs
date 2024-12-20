using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class HandleDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Billing__Booking__59063A47",
                table: "Billing");

            migrationBuilder.DropForeignKey(
                name: "FK__Booking__GuestID__4CA06362",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK__Booking__RoomID__4D94879B",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK__BookingSe__Booki__5441852A",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK__BookingSe__Servi__5535A963",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK__Room__RoomTypeID__3F466844",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK__RoomAmeni__Ameni__46E78A0C",
                table: "RoomAmenity");

            migrationBuilder.DropForeignKey(
                name: "FK__RoomAmeni__RoomI__45F365D3",
                table: "RoomAmenity");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeID",
                table: "Room",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Billing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__Billing__Booking__59063A47",
                table: "Billing",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Booking__GuestID__4CA06362",
                table: "Booking",
                column: "GuestID",
                principalTable: "Guest",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Booking__RoomID__4D94879B",
                table: "Booking",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__BookingSe__Booki__5441852A",
                table: "BookingService",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__BookingSe__Servi__5535A963",
                table: "BookingService",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Room__RoomTypeID__3F466844",
                table: "Room",
                column: "RoomTypeID",
                principalTable: "RoomType",
                principalColumn: "RoomTypeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__RoomAmeni__Ameni__46E78A0C",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "AmenityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__RoomAmeni__RoomI__45F365D3",
                table: "RoomAmenity",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Billing__Booking__59063A47",
                table: "Billing");

            migrationBuilder.DropForeignKey(
                name: "FK__Booking__GuestID__4CA06362",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK__Booking__RoomID__4D94879B",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK__BookingSe__Booki__5441852A",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK__BookingSe__Servi__5535A963",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK__Room__RoomTypeID__3F466844",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK__RoomAmeni__Ameni__46E78A0C",
                table: "RoomAmenity");

            migrationBuilder.DropForeignKey(
                name: "FK__RoomAmeni__RoomI__45F365D3",
                table: "RoomAmenity");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeID",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Billing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Billing__Booking__59063A47",
                table: "Billing",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK__Booking__GuestID__4CA06362",
                table: "Booking",
                column: "GuestID",
                principalTable: "Guest",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK__Booking__RoomID__4D94879B",
                table: "Booking",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK__BookingSe__Booki__5441852A",
                table: "BookingService",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK__BookingSe__Servi__5535A963",
                table: "BookingService",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK__Room__RoomTypeID__3F466844",
                table: "Room",
                column: "RoomTypeID",
                principalTable: "RoomType",
                principalColumn: "RoomTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK__RoomAmeni__Ameni__46E78A0C",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "AmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK__RoomAmeni__RoomI__45F365D3",
                table: "RoomAmenity",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID");
        }
    }
}
