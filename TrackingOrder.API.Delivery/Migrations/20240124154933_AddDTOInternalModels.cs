using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingOrder.API.Delivery.Migrations
{
    /// <inheritdoc />
    public partial class AddDTOInternalModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "OrderId",
                keyValue: new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"),
                column: "UpdateDate",
                value: new DateTime(2024, 1, 24, 19, 19, 32, 877, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "OrderId",
                keyValue: new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                column: "UpdateDate",
                value: new DateTime(2024, 1, 24, 19, 19, 32, 877, DateTimeKind.Local).AddTicks(7788));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "OrderId",
                keyValue: new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"),
                column: "UpdateDate",
                value: new DateTime(2024, 1, 23, 22, 1, 35, 146, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "OrderTrackings",
                keyColumn: "OrderId",
                keyValue: new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                column: "UpdateDate",
                value: new DateTime(2024, 1, 23, 22, 1, 35, 146, DateTimeKind.Local).AddTicks(3376));
        }
    }
}
