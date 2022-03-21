using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SPSonuclar",
            //    columns: table => new
            //    {
            //        FATURA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        MUSTERI_ID = table.Column<int>(type: "int", nullable: false),
            //        toplamBorc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPSonuclar");
        }
    }
}
