using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Solvace.TechCase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlanStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlanStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    ActionPlanStatusId = table.Column<long>(type: "INTEGER", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlans_ActionPlanStatus_ActionPlanStatusId",
                        column: x => x.ActionPlanStatusId,
                        principalTable: "ActionPlanStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionPlanStatus",
                columns: new[] { "Id", "CreatedAt", "ExternalId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 0, 0, 0, 0)), "17b7b9ca-f00c-4567-8023-47e1c8f80971", true, "OPEN" },
                    { 2L, new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 0, 0, 0, 0)), "ce5dd49b-85e9-40d0-87fa-e47327e382bf", true, "IN_PROGRESS" },
                    { 3L, new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "8203c033-f38c-4c94-9686-a5b0d27d98d0", true, "COMPLETED" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlans_ActionPlanStatusId",
                table: "ActionPlans",
                column: "ActionPlanStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionPlans");

            migrationBuilder.DropTable(
                name: "ActionPlanStatus");
        }
    }
}
