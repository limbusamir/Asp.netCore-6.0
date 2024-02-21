using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADBLTrainingReport.Migrations
{
    public partial class CreateDatabaseAndCreateTargetGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sdbl_tagregtGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    targetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sdbl_tagregtGroup", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sdbl_tagregtGroup");
        }
    }
}
