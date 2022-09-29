using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class RevisadoNotificação : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 643, DateTimeKind.Local).AddTicks(3735),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 17, 9, 58, 36, 444, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 644, DateTimeKind.Local).AddTicks(297),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 643, DateTimeKind.Local).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.AddColumn<string>(
                name: "comments",
                table: "notification",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "vehicle_license_plate",
                table: "notification",
                type: "VARCHAR(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 22, 19, 12, 59, 643, DateTimeKind.Local).AddTicks(4950));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comments",
                table: "notification");

            migrationBuilder.DropColumn(
                name: "vehicle_license_plate",
                table: "notification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 9, 58, 36, 444, DateTimeKind.Local).AddTicks(8440),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 643, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(2310),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 644, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(1988),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 22, 19, 12, 59, 643, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 17, 9, 58, 36, 445, DateTimeKind.Local).AddTicks(1664));
        }
    }
}
