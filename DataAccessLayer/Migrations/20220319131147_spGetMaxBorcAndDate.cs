using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class spGetMaxBorcAndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            IF OBJECT_ID('GetMaxBorcAndDate', 'P') IS NOT NULL
            DROP PROC GetMaxBorcAndDate
            GO

           CREATE PROCEDURE dbo.GetMaxBorcAndDate @musterId int
            AS
            select top 1 m1.FATURA_TARIHI,m1.MUSTERI_ID, 
            (
            select SUM(FATURA_TUTARI) from musteri_fatura_table m2 where MUSTERI_ID=m1.MUSTERI_ID
            and m2.FATURA_TARIHI<=m1.FATURA_TARIHI and m2.ODEME_TARIHI>m1.FATURA_TARIHI
            ) toplamBorc
            from musteri_fatura_table m1
            where MUSTERI_ID=@musterId
            group by FATURA_TARIHI,MUSTERI_ID
            order by toplamBorc desc";

            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
