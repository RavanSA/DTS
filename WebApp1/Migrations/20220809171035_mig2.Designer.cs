﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp1.Models;

namespace WebApp1.Migrations
{
    [DbContext(typeof(HukukDTSContext))]
    [Migration("20220809171035_mig2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp1.Models.Dava", b =>
                {
                    b.Property<int>("DavaKayitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<int?>("DavaFormTipi")
                        .HasColumnType("int");

                    b.Property<string>("DavaKonusu")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DavaTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("DavaTuruKayitNo")
                        .HasColumnName("DavaTuru_KayitNo")
                        .HasColumnType("int");

                    b.Property<double?>("DavaTutari")
                        .HasColumnType("float");

                    b.Property<string>("Davaci")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Davali")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DefterSiraNo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("DegistirenKisi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DegistirilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("DigerDavacilar")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("DigerDavalilar")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("EsasNo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<double?>("IslahDegeri")
                        .HasColumnType("float");

                    b.Property<bool?>("Lehte")
                        .HasColumnType("bit");

                    b.Property<string>("Mahkemesi")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("OlusturulmaTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("ParaBirimiKayitNo")
                        .HasColumnName("ParaBirimi_KayitNo")
                        .HasColumnType("int");

                    b.Property<bool?>("SonucTahmini")
                        .HasColumnType("bit");

                    b.Property<bool?>("TemyizEdildi")
                        .HasColumnType("bit");

                    b.Property<int?>("TopluDavaKayitNo")
                        .HasColumnType("int");

                    b.Property<string>("YargitayDosyaNo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("DavaKayitNo")
                        .HasName("PK_Davalar");

                    b.HasIndex("DavaTuruKayitNo");

                    b.HasIndex("ParaBirimiKayitNo");

                    b.ToTable("Dava");
                });

            modelBuilder.Entity("WebApp1.Models.DavaEki", b =>
                {
                    b.Property<int>("KayitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DavaKayitNo")
                        .HasColumnName("Dava_KayitNo")
                        .HasColumnType("int");

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<byte[]>("Ek")
                        .HasColumnType("image");

                    b.Property<int?>("SiraNo")
                        .HasColumnType("int");

                    b.HasKey("KayitNo")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("DavaKayitNo");

                    b.ToTable("DavaEki");
                });

            modelBuilder.Entity("WebApp1.Models.DavaEx", b =>
                {
                    b.Property<string>("Aciklama")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<int?>("DavaFormTipi")
                        .HasColumnType("int");

                    b.Property<int>("DavaKayitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DavaKonusu")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DavaTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("DavaTuruKayitNo")
                        .HasColumnName("DavaTuru_KayitNo")
                        .HasColumnType("int");

                    b.Property<double?>("DavaTutari")
                        .HasColumnType("float");

                    b.Property<string>("Davaci")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Davali")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DefterSiraNo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("DegistirenKisi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DegistirilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("DigerDavacilar")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("DigerDavalilar")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("EsasNo")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<double?>("IslahDegeri")
                        .HasColumnType("float");

                    b.Property<bool?>("Lehte")
                        .HasColumnType("bit");

                    b.Property<string>("Mahkemesi")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("OlusturanKisi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("OlusturulmaTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("ParaBirimiKayitNo")
                        .HasColumnName("ParaBirimi_KayitNo")
                        .HasColumnType("int");

                    b.Property<bool?>("SonucTahmini")
                        .HasColumnType("bit");

                    b.Property<bool?>("TemyizEdildi")
                        .HasColumnType("bit");

                    b.Property<int?>("TopluDavaKayitNo")
                        .HasColumnType("int");

                    b.Property<string>("YargitayDosyaNo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.ToTable("DavaEx");
                });

            modelBuilder.Entity("WebApp1.Models.DavaSonucu", b =>
                {
                    b.Property<int>("DavaKayitNo")
                        .HasColumnName("Dava_KayitNo")
                        .HasColumnType("int");

                    b.Property<double?>("AsilAlacak")
                        .HasColumnType("float");

                    b.Property<bool?>("DavaSonucu1")
                        .HasColumnName("DavaSonucu")
                        .HasColumnType("bit");

                    b.Property<double?>("IcraMasraflari")
                        .HasColumnType("float");

                    b.Property<string>("IcraSafhasi")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<double?>("IcraVekaletUcreti")
                        .HasColumnType("float");

                    b.Property<double?>("IslenmisFaiz")
                        .HasColumnType("float");

                    b.Property<string>("KaldirmaNo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<double?>("MahkemeHarcveMasrafi")
                        .HasColumnType("float");

                    b.Property<DateTime?>("OdemeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SonucTarihi")
                        .HasColumnType("datetime");

                    b.Property<double?>("VekaletUcretleri")
                        .HasColumnType("float");

                    b.HasKey("DavaKayitNo")
                        .HasName("PK_DavaSonuclari");

                    b.ToTable("DavaSonucu");
                });

            modelBuilder.Entity("WebApp1.Models.DavaTuru", b =>
                {
                    b.Property<int?>("KayitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SiraNo")
                        .HasColumnType("int");

                    b.Property<string>("Tanim")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("KayitNo");

                    b.ToTable("DavaTuru");
                });

            modelBuilder.Entity("WebApp1.Models.EPetkimDavalarForm", b =>
                {
                    b.Property<string>("Aciklamasi")
                        .HasColumnType("varchar(7500)")
                        .HasMaxLength(7500)
                        .IsUnicode(false);

                    b.Property<int?>("Aleyhe")
                        .HasColumnType("int");

                    b.Property<decimal?>("AleyheDavaninDegeri")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("DavaAy")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DavaGun")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DavaOzeti")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DavaSonucuTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("DavaTar")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DavaTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("DavaTurleri")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("DavaTurleriText")
                        .HasColumnName("DavaTurleri_TEXT")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("DavaVekili")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DavaYil")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Davaci")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DavaciVekili")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Davali")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DefterSiraNo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DigerDavacilar")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DigerDavali")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DigerDavalilar")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("EsasNo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Fdate")
                        .HasColumnName("FDATE")
                        .HasColumnType("datetime");

                    b.Property<string>("Flow")
                        .HasColumnName("FLOW")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Followstatus")
                        .HasColumnName("FOLLOWSTATUS")
                        .HasColumnType("int");

                    b.Property<string>("FormNo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnName("ID")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal?>("IslahDegeri")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("KaldirmaNo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("KararNumarasi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("KararTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("KararinOzeti")
                        .HasColumnType("varchar(7500)")
                        .HasMaxLength(7500)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Lastchange")
                        .HasColumnName("LASTCHANGE")
                        .HasColumnType("datetime");

                    b.Property<int?>("Lehe")
                        .HasColumnType("int");

                    b.Property<decimal?>("LeheDavaninDegeri")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Linkdesc")
                        .HasColumnName("LINKDESC")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("MahkemeAdi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MahkemeTipi")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("MahkemeTipiText")
                        .HasColumnName("MahkemeTipi_TEXT")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Metin1")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Metin2")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Processlink")
                        .HasColumnName("PROCESSLINK")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Rdate")
                        .HasColumnName("RDATE")
                        .HasColumnType("datetime");

                    b.Property<string>("Ruser")
                        .HasColumnName("RUSER")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Sonuc")
                        .HasColumnName("sonuc")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("SonucText")
                        .HasColumnName("sonuc_TEXT")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("TemyizAciklamasi")
                        .HasColumnType("varchar(7500)")
                        .HasMaxLength(7500)
                        .IsUnicode(false);

                    b.Property<int?>("TemyizEdildim")
                        .HasColumnType("int");

                    b.Property<int?>("TemyizEdilmedim")
                        .HasColumnType("int");

                    b.Property<string>("TemyizNumarasi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("TemyizTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("Version")
                        .HasColumnName("VERSION")
                        .HasColumnType("int");

                    b.Property<string>("YeniDavaOzeti")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.ToTable("E_PetkimDavalar_Form");
                });

            modelBuilder.Entity("WebApp1.Models.EPetkimDavalarFormSonuc", b =>
                {
                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnName("ID")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnName("TEXT")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.ToTable("E_PetkimDavalar_Form_sonuc");
                });

            modelBuilder.Entity("WebApp1.Models.KolonIsimleri", b =>
                {
                    b.Property<string>("TabloAdi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("KolonAdi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("KolonTakmaAdi")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid>("RowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RowID")
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("TabloAdi", "KolonAdi");

                    b.ToTable("KolonIsimleri");
                });

            modelBuilder.Entity("WebApp1.Models.ParaBirimi", b =>
                {
                    b.Property<int>("KayitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParaBirimiKodu")
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    b.Property<int?>("SiraNo")
                        .HasColumnType("int");

                    b.Property<string>("Tanimi")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("KayitNo")
                        .HasName("PK_ParaBirimleri");

                    b.ToTable("ParaBirimi");
                });

            modelBuilder.Entity("WebApp1.Models.Temyiz", b =>
                {
                    b.Property<int>("DavaKayitNo")
                        .HasColumnName("Dava_KayitNo")
                        .HasColumnType("int");

                    b.Property<string>("Aciklama")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<bool?>("TemyizEdenPetkim")
                        .HasColumnType("bit");

                    b.Property<bool?>("TemyizSonucu")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TemyizTarihi")
                        .HasColumnType("datetime");

                    b.HasKey("DavaKayitNo");

                    b.ToTable("Temyiz");
                });

            modelBuilder.Entity("WebApp1.Models.YerelMahkemeKarari", b =>
                {
                    b.Property<int>("DavaKayitNo")
                        .HasColumnName("Dava_KayitNo")
                        .HasColumnType("int");

                    b.Property<string>("KararNo")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("KararOzeti")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<bool?>("KararSonucu")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("KararTarihi")
                        .HasColumnType("datetime");

                    b.HasKey("DavaKayitNo");

                    b.ToTable("YerelMahkemeKarari");
                });

            modelBuilder.Entity("WebApp1.Models.Dava", b =>
                {
                    b.HasOne("WebApp1.Models.DavaTuru", "DavaTuruKayitNoNavigation")
                        .WithMany("Dava")
                        .HasForeignKey("DavaTuruKayitNo")
                        .HasConstraintName("FK_Dava_DavaTuru");

                    b.HasOne("WebApp1.Models.ParaBirimi", "ParaBirimiKayitNoNavigation")
                        .WithMany("Dava")
                        .HasForeignKey("ParaBirimiKayitNo")
                        .HasConstraintName("FK_Dava_ParaBirimi");
                });

            modelBuilder.Entity("WebApp1.Models.DavaEki", b =>
                {
                    b.HasOne("WebApp1.Models.Dava", "DavaKayitNoNavigation")
                        .WithMany("DavaEki")
                        .HasForeignKey("DavaKayitNo")
                        .HasConstraintName("FK_DavaEki_Dava")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.DavaSonucu", b =>
                {
                    b.HasOne("WebApp1.Models.Dava", "DavaKayitNoNavigation")
                        .WithOne("DavaSonucu")
                        .HasForeignKey("WebApp1.Models.DavaSonucu", "DavaKayitNo")
                        .HasConstraintName("FK_DavaSonucu_Dava")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp1.Models.Temyiz", b =>
                {
                    b.HasOne("WebApp1.Models.Dava", "DavaKayitNoNavigation")
                        .WithOne("Temyiz")
                        .HasForeignKey("WebApp1.Models.Temyiz", "DavaKayitNo")
                        .HasConstraintName("FK_Temyiz_Dava")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp1.Models.YerelMahkemeKarari", b =>
                {
                    b.HasOne("WebApp1.Models.Dava", "DavaKayitNoNavigation")
                        .WithOne("YerelMahkemeKarari")
                        .HasForeignKey("WebApp1.Models.YerelMahkemeKarari", "DavaKayitNo")
                        .HasConstraintName("FK_YerelMahkemeKarari_Dava")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}