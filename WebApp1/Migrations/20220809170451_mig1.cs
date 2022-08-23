using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "DavaEx",
            //    columns: table => new
            //    {
            //        DavaKayitNo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EsasNo = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        DefterSiraNo = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        YargitayDosyaNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        DavaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DavaTuru_KayitNo = table.Column<int>(nullable: true),
            //        DavaKonusu = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        Lehte = table.Column<bool>(nullable: true),
            //        SonucTahmini = table.Column<bool>(nullable: true),
            //        Mahkemesi = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        DavaTutari = table.Column<double>(nullable: true),
            //        IslahDegeri = table.Column<double>(nullable: true),
            //        ParaBirimi_KayitNo = table.Column<int>(nullable: true),
            //        Davaci = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Davali = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DigerDavacilar = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        DigerDavalilar = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        Aciklama = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
            //        OlusturulmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DegistirilmeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        OlusturanKisi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DegistirenKisi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaFormTipi = table.Column<int>(nullable: true),
            //        TopluDavaKayitNo = table.Column<int>(nullable: true),
            //        TemyizEdildi = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DavaTuru",
            //    columns: table => new
            //    {
            //        KayitNo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Tanim = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        SiraNo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DavaTuru", x => x.KayitNo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "E_PetkimDavalar_Form",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        RUSER = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        RDATE = table.Column<DateTime>(type: "datetime", nullable: true),
            //        FDATE = table.Column<DateTime>(type: "datetime", nullable: true),
            //        STATUS = table.Column<int>(nullable: true),
            //        VERSION = table.Column<int>(nullable: true),
            //        LASTCHANGE = table.Column<DateTime>(type: "datetime", nullable: true),
            //        FOLLOWSTATUS = table.Column<int>(nullable: true),
            //        PROCESSLINK = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        LINKDESC = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
            //        FLOW = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        EsasNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Davaci = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Davali = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        MahkemeAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        LeheDavaninDegeri = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        KararinOzeti = table.Column<string>(unicode: false, maxLength: 7500, nullable: true),
            //        KararTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        KararNumarasi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        TemyizTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        TemyizNumarasi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Aciklamasi = table.Column<string>(unicode: false, maxLength: 7500, nullable: true),
            //        DavaciVekili = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        TemyizAciklamasi = table.Column<string>(unicode: false, maxLength: 7500, nullable: true),
            //        FormNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        KaldirmaNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        MahkemeTipi = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        MahkemeTipi_TEXT = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        YeniDavaOzeti = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Metin1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaVekili = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Metin2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        AleyheDavaninDegeri = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        DavaSonucuTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DefterSiraNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaTar = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaOzeti = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        sonuc = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        sonuc_TEXT = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        TemyizEdildim = table.Column<int>(nullable: true),
            //        TemyizEdilmedim = table.Column<int>(nullable: true),
            //        IslahDegeri = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        DavaYil = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaAy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaGun = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaTurleri = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        DavaTurleri_TEXT = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        DigerDavali = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DigerDavacilar = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DigerDavalilar = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Lehe = table.Column<int>(nullable: true),
            //        Aleyhe = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "E_PetkimDavalar_Form_sonuc",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
            //        TEXT = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
            //        STATUS = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "KolonIsimleri",
            //    columns: table => new
            //    {
            //        TabloAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        KolonAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        KolonTakmaAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        RowID = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KolonIsimleri", x => new { x.TabloAdi, x.KolonAdi });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ParaBirimi",
            //    columns: table => new
            //    {
            //        KayitNo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ParaBirimiKodu = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
            //        Tanimi = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        SiraNo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ParaBirimleri", x => x.KayitNo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Dava",
            //    columns: table => new
            //    {
            //        DavaKayitNo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EsasNo = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        DefterSiraNo = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        YargitayDosyaNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        DavaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DavaTuru_KayitNo = table.Column<int>(nullable: true),
            //        DavaKonusu = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        Lehte = table.Column<bool>(nullable: true),
            //        SonucTahmini = table.Column<bool>(nullable: true),
            //        Mahkemesi = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        DavaTutari = table.Column<double>(nullable: true),
            //        IslahDegeri = table.Column<double>(nullable: true),
            //        ParaBirimi_KayitNo = table.Column<int>(nullable: true),
            //        Davaci = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Davali = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DigerDavacilar = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        DigerDavalilar = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        Aciklama = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
            //        OlusturulmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DegistirilmeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        OlusturanKisi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DegistirenKisi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DavaFormTipi = table.Column<int>(nullable: true),
            //        TopluDavaKayitNo = table.Column<int>(nullable: true),
            //        TemyizEdildi = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Davalar", x => x.DavaKayitNo);
            //        table.ForeignKey(
            //            name: "FK_Dava_DavaTuru",
            //            column: x => x.DavaTuru_KayitNo,
            //            principalTable: "DavaTuru",
            //            principalColumn: "KayitNo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Dava_ParaBirimi",
            //            column: x => x.ParaBirimi_KayitNo,
            //            principalTable: "ParaBirimi",
            //            principalColumn: "KayitNo",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Dava_Dava",
            //            column: x => x.TopluDavaKayitNo,
            //            principalTable: "Dava",
            //            principalColumn: "DavaKayitNo",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DavaEki",
            //    columns: table => new
            //    {
            //        KayitNo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Dava_KayitNo = table.Column<int>(nullable: true),
            //        DosyaAdi = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        Ek = table.Column<byte[]>(type: "image", nullable: true),
            //        SiraNo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DavaEki", x => x.KayitNo)
            //            .Annotation("SqlServer:Clustered", false);
            //        table.ForeignKey(
            //            name: "FK_DavaEki_Dava",
            //            column: x => x.Dava_KayitNo,
            //            principalTable: "Dava",
            //            principalColumn: "DavaKayitNo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DavaSonucu",
            //    columns: table => new
            //    {
            //        Dava_KayitNo = table.Column<int>(nullable: false),
            //        SonucTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        KaldirmaNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        DavaSonucu = table.Column<bool>(nullable: true),
            //        IcraSafhasi = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
            //        AsilAlacak = table.Column<double>(nullable: true),
            //        IslenmisFaiz = table.Column<double>(nullable: true),
            //        MahkemeHarcveMasrafi = table.Column<double>(nullable: true),
            //        IcraMasraflari = table.Column<double>(nullable: true),
            //        VekaletUcretleri = table.Column<double>(nullable: true),
            //        IcraVekaletUcreti = table.Column<double>(nullable: true),
            //        OdemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DavaSonuclari", x => x.Dava_KayitNo);
            //        table.ForeignKey(
            //            name: "FK_DavaSonucu_Dava",
            //            column: x => x.Dava_KayitNo,
            //            principalTable: "Dava",
            //            principalColumn: "DavaKayitNo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Temyiz",
            //    columns: table => new
            //    {
            //        Dava_KayitNo = table.Column<int>(nullable: false),
            //        TemyizEdenPetkim = table.Column<bool>(nullable: true),
            //        TemyizTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        TemyizSonucu = table.Column<bool>(nullable: true),
            //        Aciklama = table.Column<string>(unicode: false, maxLength: 8000, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Temyiz", x => x.Dava_KayitNo);
            //        table.ForeignKey(
            //            name: "FK_Temyiz_Dava",
            //            column: x => x.Dava_KayitNo,
            //            principalTable: "Dava",
            //            principalColumn: "DavaKayitNo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "YerelMahkemeKarari",
            //    columns: table => new
            //    {
            //        Dava_KayitNo = table.Column<int>(nullable: false),
            //        KararNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        KararTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
            //        KararSonucu = table.Column<bool>(nullable: true),
            //        KararOzeti = table.Column<string>(unicode: false, maxLength: 8000, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_YerelMahkemeKarari", x => x.Dava_KayitNo);
            //        table.ForeignKey(
            //            name: "FK_YerelMahkemeKarari_Dava",
            //            column: x => x.Dava_KayitNo,
            //            principalTable: "Dava",
            //            principalColumn: "DavaKayitNo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dava_DavaTuru_KayitNo",
            //    table: "Dava",
            //    column: "DavaTuru_KayitNo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dava_ParaBirimi_KayitNo",
            //    table: "Dava",
            //    column: "ParaBirimi_KayitNo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dava_TopluDavaKayitNo",
            //    table: "Dava",
            //    column: "TopluDavaKayitNo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DavaEki_Dava_KayitNo",
            //    table: "DavaEki",
            //    column: "Dava_KayitNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "DavaEki");

            //migrationBuilder.DropTable(
            //    name: "DavaEx");

            //migrationBuilder.DropTable(
            //    name: "DavaSonucu");

            //migrationBuilder.DropTable(
            //    name: "E_PetkimDavalar_Form");

            //migrationBuilder.DropTable(
            //    name: "E_PetkimDavalar_Form_sonuc");

            //migrationBuilder.DropTable(
            //    name: "KolonIsimleri");

            //migrationBuilder.DropTable(
            //    name: "Temyiz");

            //migrationBuilder.DropTable(
            //    name: "YerelMahkemeKarari");

            //migrationBuilder.DropTable(
            //    name: "Dava");

            //migrationBuilder.DropTable(
            //    name: "DavaTuru");

            //migrationBuilder.DropTable(
            //    name: "ParaBirimi");
        }
    }
}
