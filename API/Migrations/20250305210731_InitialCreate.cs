using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), "Descripcion", "Test" },
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45508"), "Descripcion2", "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45509"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1710), "Descripcion1", true, 1, "Tarea1" },
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45510"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1717), "Descripcion2", true, 2, "Tarea2" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new Guid("8f31917c-5d9b-42d8-89a2-8d23d72c3088"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45508"), new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1720), "Descripcion3", 3, "Tarea3" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
