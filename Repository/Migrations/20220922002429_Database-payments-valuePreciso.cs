using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class DatabasepaymentsvaluePreciso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 921, DateTimeKind.Local).AddTicks(6550),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 303, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "payments",
                type: "DECIMAL(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(38,17)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(2310),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 304, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(1988),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 304, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 21, 21, 24, 28, 921, DateTimeKind.Local).AddTicks(8386));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 303, DateTimeKind.Local).AddTicks(9673),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 921, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                table: "payments",
                type: "DECIMAL(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 304, DateTimeKind.Local).AddTicks(5444),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 21, 20, 56, 43, 304, DateTimeKind.Local).AddTicks(4993),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 21, 21, 24, 28, 922, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 21, 20, 56, 43, 304, DateTimeKind.Local).AddTicks(1499));
        }
    }
}
