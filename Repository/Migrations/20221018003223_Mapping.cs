using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class Mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(8564),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 482, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(2134),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 483, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(1925),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 483, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "payments",
                type: "VARCHAR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "payments",
                type: "VARCHAR",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(5052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 484, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(9591));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "payments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 482, DateTimeKind.Local).AddTicks(8696),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 483, DateTimeKind.Local).AddTicks(4501),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 483, DateTimeKind.Local).AddTicks(3927),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 29, 20, 58, 56, 484, DateTimeKind.Local).AddTicks(367),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 29, 20, 58, 56, 483, DateTimeKind.Local).AddTicks(517));
        }
    }
}
