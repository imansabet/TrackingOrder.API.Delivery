using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrackingOrder.API.Delivery.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTrackings",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryVehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackings", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "OrderTrackings",
                columns: new[] { "OrderId", "DeliveryPerson", "DeliveryVehicle", "IsDelivered", "Location", "PhoneNumber", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), "Jane Smith", "Van", true, "Customer's Address", "987654321", "Delivered", new DateTime(2024, 1, 23, 22, 1, 35, 146, DateTimeKind.Local).AddTicks(3390) },
                    { new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "John Doe", "Truck", false, "Warehouse", "123456789", "In Progress", new DateTime(2024, 1, 23, 22, 1, 35, 146, DateTimeKind.Local).AddTicks(3376) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTrackings");
        }
    }
}
