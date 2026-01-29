using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globoticket.Services.ShoppingBasket.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketChangeEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InsertedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    BasketChangeType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketChangeEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLines",
                columns: table => new
                {
                    BasketLineId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BasketId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLines", x => x.BasketLineId);
                    table.ForeignKey(
                        name: "FK_BasketLines_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketLines_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Date", "Name" },
                values: new object[,]
                {
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new DateTime(2026, 7, 16, 12, 19, 46, 703, DateTimeKind.Local).AddTicks(5165), "Techorama 2021" },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new DateTime(2026, 6, 16, 12, 19, 46, 703, DateTimeKind.Local).AddTicks(5141), "The State of Affairs: Michael Live!" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new DateTime(2026, 1, 16, 12, 19, 46, 703, DateTimeKind.Local).AddTicks(5163), "Spanish guitar hits with Manuel" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new DateTime(2026, 5, 16, 12, 19, 46, 703, DateTimeKind.Local).AddTicks(5167), "To the Moon and Back" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new DateTime(2026, 1, 16, 12, 19, 46, 703, DateTimeKind.Local).AddTicks(5159), "Clash of the DJs" },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new DateTime(2026, 3, 16, 12, 19, 46, 701, DateTimeKind.Local).AddTicks(385), "John Egbert Live" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_EventId",
                table: "BasketLines",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketChangeEvents");

            migrationBuilder.DropTable(
                name: "BasketLines");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
