using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class Databasepaymentsdefaultvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 238, DateTimeKind.Local).AddTicks(8613),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 18, 41, 9, 377, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 239, DateTimeKind.Local).AddTicks(4810),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 239, DateTimeKind.Local).AddTicks(4494),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "payments",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 21, 19, 57, 38, 239, DateTimeKind.Local).AddTicks(514));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 18, 41, 9, 377, DateTimeKind.Local).AddTicks(657),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 238, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 239, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 19, 57, 38, 239, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "payments",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 21, 18, 41, 9, 377, DateTimeKind.Local).AddTicks(2330));
        }
    }
}
