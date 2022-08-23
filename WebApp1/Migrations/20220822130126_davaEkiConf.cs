using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class davaEkiConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dava_DavaTuru",
                table: "Dava");

            migrationBuilder.AlterColumn<string>(
                name: "KararOzeti",
                table: "YerelMahkemeKarari",
                unicode: false,
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldUnicode: false,
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KararNo",
                table: "YerelMahkemeKarari",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Temyiz",
                unicode: false,
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldUnicode: false,
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KaldirmaNo",
                table: "DavaSonucu",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IcraSafhasi",
                table: "DavaSonucu",
                unicode: false,
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldUnicode: false,
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosyaTuru",
                table: "DavaEki",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YargitayDosyaNo",
                table: "Dava",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OlusturanKisi",
                table: "Dava",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mahkemesi",
                table: "Dava",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EsasNo",
                table: "Dava",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DigerDavalilar",
                table: "Dava",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DigerDavacilar",
                table: "Dava",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DegistirenKisi",
                table: "Dava",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DefterSiraNo",
                table: "Dava",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Davali",
                table: "Dava",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Davaci",
                table: "Dava",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DavaTuru_KayitNo",
                table: "Dava",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DavaKonusu",
                table: "Dava",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dava",
                unicode: false,
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldUnicode: false,
                oldMaxLength: 8000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dava_DavaTuru",
                table: "Dava",
                column: "DavaTuru_KayitNo",
                principalTable: "DavaTuru",
                principalColumn: "KayitNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dava_DavaTuru",
                table: "Dava");

            migrationBuilder.DropColumn(
                name: "DosyaTuru",
                table: "DavaEki");

            migrationBuilder.AlterColumn<string>(
                name: "KararOzeti",
                table: "YerelMahkemeKarari",
                type: "varchar(8000)",
                unicode: false,
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "KararNo",
                table: "YerelMahkemeKarari",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Temyiz",
                type: "varchar(8000)",
                unicode: false,
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "KaldirmaNo",
                table: "DavaSonucu",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "IcraSafhasi",
                table: "DavaSonucu",
                type: "varchar(8000)",
                unicode: false,
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "YargitayDosyaNo",
                table: "Dava",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "OlusturanKisi",
                table: "Dava",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Mahkemesi",
                table: "Dava",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EsasNo",
                table: "Dava",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DigerDavalilar",
                table: "Dava",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DigerDavacilar",
                table: "Dava",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DegistirenKisi",
                table: "Dava",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DefterSiraNo",
                table: "Dava",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Davali",
                table: "Dava",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Davaci",
                table: "Dava",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DavaTuru_KayitNo",
                table: "Dava",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DavaKonusu",
                table: "Dava",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dava",
                type: "varchar(8000)",
                unicode: false,
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8000);

            migrationBuilder.AddForeignKey(
                name: "FK_Dava_DavaTuru",
                table: "Dava",
                column: "DavaTuru_KayitNo",
                principalTable: "DavaTuru",
                principalColumn: "KayitNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
