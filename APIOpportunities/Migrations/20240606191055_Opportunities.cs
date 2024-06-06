using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIOpportunities.Migrations
{
    public partial class Opportunities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutbreakLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursQtd = table.Column<long>(type: "bigint", nullable: false),
                    ErrorsQtd = table.Column<long>(type: "bigint", nullable: false),
                    LearnLevel = table.Column<long>(type: "bigint", nullable: false),
                    HoursSleep = table.Column<long>(type: "bigint", nullable: false),
                    HoursOff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunity");
        }
    }
}
