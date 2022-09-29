using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class AtualizadoNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "notification",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "notification",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(2),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 492, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(4054),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 493, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(3791),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 493, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "notification",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<byte>(
                name: "notification_amount",
                table: "notification",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(6959),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(1460));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "notification",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "notification",
                newName: "create_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 492, DateTimeKind.Local).AddTicks(7861),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 493, DateTimeKind.Local).AddTicks(2104),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(4054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "payments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 26, 21, 24, 39, 493, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.AlterColumn<byte>(
                name: "notification_amount",
                table: "notification",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT",
                oldDefaultValue: (byte)1);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "notification",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "notification",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2022, 9, 28, 20, 59, 23, 73, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2022, 9, 26, 21, 24, 39, 492, DateTimeKind.Local).AddTicks(9030));
        }
    }
}
