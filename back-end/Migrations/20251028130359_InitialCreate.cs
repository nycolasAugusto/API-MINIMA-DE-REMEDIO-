using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRemedio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remedios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeRemedio = table.Column<string>(type: "TEXT", nullable: false),
                    dataValidade = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    marca = table.Column<string>(type: "TEXT", nullable: false),
                    miligramas = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remedios");
        }
    }
}
