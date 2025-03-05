using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Resumen = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    PrioridadTarea = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tareas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Resumen" },
                values: new object[,]
                {
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), "Descripcion", "Test", "Resumen" },
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45508"), "Descripcion2", "Test2", "Resumen2" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "IsActive", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45509"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), "Descripcion1", new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1710), true, 2, "Tarea1" },
                    { new Guid("264b59f3-2346-4f72-b1fc-a6842bb45510"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45507"), "Descripcion2", new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1717), true, 1, "Tarea2" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("8f31917c-5d9b-42d8-89a2-8d23d72c3088"), new Guid("264b59f3-2346-4f72-b1fc-a6842bb45508"), "Descripcion3", new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1720), 0, "Tarea3" });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaId",
                table: "Tareas",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
