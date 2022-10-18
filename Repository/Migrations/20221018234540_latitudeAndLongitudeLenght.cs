using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class latitudeAndLongitudeLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 739, DateTimeKind.Local).AddTicks(6561),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 740, DateTimeKind.Local).AddTicks(3959),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "payments",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "payments",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 740, DateTimeKind.Local).AddTicks(3397),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 741, DateTimeKind.Local).AddTicks(621),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 10, 18, 20, 45, 39, 739, DateTimeKind.Local).AddTicks(8651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(8564),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 739, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(2134),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 740, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "payments",
                type: "VARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "payments",
                type: "VARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(1925),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 740, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 21, 32, 23, 648, DateTimeKind.Local).AddTicks(5052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 10, 18, 20, 45, 39, 741, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 10, 17, 21, 32, 23, 647, DateTimeKind.Local).AddTicks(9591));
        }
    }
}
