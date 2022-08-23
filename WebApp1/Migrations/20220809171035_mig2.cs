using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Dava_Dava",
            //    table: "Dava");

            //migrationBuilder.DropIndex(
            //    name: "IX_Dava_TopluDavaKayitNo",
            //    table: "Dava");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_Dava_TopluDavaKayitNo",
            //    table: "Dava",
            //    column: "TopluDavaKayitNo");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dava_Dava",
            //    table: "Dava",
            //    column: "TopluDavaKayitNo",
            //    principalTable: "Dava",
            //    principalColumn: "DavaKayitNo",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
