using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "guards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identification_number = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    user_id = table.Column<int>(type: "INT", nullable: false),
                    status = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    create_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    update_at = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_guards_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_plate = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicle_type = table.Column<byte>(type: "TINYINT", nullable: false),
                    user_id = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    update_at = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    register_vehicle = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    address = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    guard_id = table.Column<int>(type: "INT", nullable: false),
                    vehicle_id = table.Column<int>(type: "INT", nullable: false),
                    status = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    create_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    update_at = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notification_guards_guard_id",
                        column: x => x.guard_id,
                        principalTable: "guards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notification_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "INT", nullable: false),
                    vehicle_id = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false),
                    create_at = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    update_at = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_guards_user_id",
                table: "guards",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_guard_id",
                table: "notification",
                column: "guard_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_vehicle_id",
                table: "notification",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_user_id",
                table: "payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_vehicle_id",
                table: "payments",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_user_id",
                table: "vehicles",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "guards");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
