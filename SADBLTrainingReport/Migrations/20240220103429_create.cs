using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADBLTrainingReport.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramName",
                table: "ProgramName");

            migrationBuilder.RenameTable(
                name: "ProgramName",
                newName: "sdbl_programName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sdbl_programName",
                table: "sdbl_programName",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "sdbl_organizer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organizerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_On = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sdbl_organizer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sdbl_organizer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sdbl_programName",
                table: "sdbl_programName");

            migrationBuilder.RenameTable(
                name: "sdbl_programName",
                newName: "ProgramName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramName",
                table: "ProgramName",
                column: "Id");
        }
    }
}
