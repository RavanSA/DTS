using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp1.Models
{
    public partial class HukukDTSContext : DbContext
    {
        public HukukDTSContext()
        {
        }

        public HukukDTSContext(DbContextOptions<HukukDTSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AktarTemyiz> AktarTemyiz { get; set; }
        public virtual DbSet<AktarYmk> AktarYmk { get; set; }
        public virtual DbSet<Dava> Dava { get; set; }
        public virtual DbSet<DavaEki> DavaEki { get; set; }
        public virtual DbSet<DavaEx> DavaEx { get; set; }
        public virtual DbSet<DavaList> DavaList { get; set; }
        public virtual DbSet<DavaListeleri> DavaListeleri { get; set; }
        public virtual DbSet<DavaSonucu> DavaSonucu { get; set; }
        public virtual DbSet<DavaTuru> DavaTuru { get; set; }
        public virtual DbSet<EPetkimDavalarForm> EPetkimDavalarForm { get; set; }
        public virtual DbSet<EPetkimDavalarFormSonuc> EPetkimDavalarFormSonuc { get; set; }
        public virtual DbSet<Esleme> Esleme { get; set; }
        public virtual DbSet<KolonIsimleri> KolonIsimleri { get; set; }
        public virtual DbSet<OdemeBilgileriView> OdemeBilgileriView { get; set; }
        public virtual DbSet<ParaBirimi> ParaBirimi { get; set; }
        public virtual DbSet<Temyiz> Temyiz { get; set; }
        public virtual DbSet<YerelMahkemeKarari> YerelMahkemeKarari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\COAS;Initial Catalog=HukukDTS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AktarTemyiz>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("aktar_temyiz");

                entity.Property(e => e.Sonuc).HasColumnName("sonuc");

                entity.Property(e => e.TemyizAciklamasi)
                    .HasMaxLength(7500)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<AktarYmk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("aktar_ymk");

                entity.Property(e => e.KararTarihi).HasColumnType("datetime");

                entity.Property(e => e.KararinOzeti)
                    .HasMaxLength(7500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dava>(entity =>
            {
                entity.HasKey(e => e.DavaKayitNo)
                    .HasName("PK_Davalar");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTuruKayitNo).HasColumnName("DavaTuru_KayitNo");

                entity.Property(e => e.Davaci)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirenKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirilmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DigerDavacilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavalilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mahkemesi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturanKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturulmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.ParaBirimiKayitNo).HasColumnName("ParaBirimi_KayitNo");

                entity.Property(e => e.YargitayDosyaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DavaTuruKayitNoNavigation)
                    .WithMany(p => p.Dava)
                    .HasForeignKey(d => d.DavaTuruKayitNo)
                    .HasConstraintName("FK_Dava_DavaTuru");

                entity.HasOne(d => d.ParaBirimiKayitNoNavigation)
                    .WithMany(p => p.Dava)
                    .HasForeignKey(d => d.ParaBirimiKayitNo)
                    .HasConstraintName("FK_Dava_ParaBirimi");

            });

            modelBuilder.Entity<DavaEki>(entity =>
            {
                entity.HasKey(e => e.KayitNo)
                    .IsClustered(false);

                entity.Property(e => e.DavaKayitNo).HasColumnName("Dava_KayitNo");

                entity.Property(e => e.DosyaAdi)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ek).HasColumnType("image");

                entity.HasOne(d => d.DavaKayitNoNavigation)
                    .WithMany(p => p.DavaEki)
                    .HasForeignKey(d => d.DavaKayitNo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DavaEki_Dava");
            });

            modelBuilder.Entity<DavaEx>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DavaKayitNo).ValueGeneratedOnAdd();

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTuruKayitNo).HasColumnName("DavaTuru_KayitNo");

                entity.Property(e => e.Davaci)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirenKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirilmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DigerDavacilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavalilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mahkemesi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturanKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturulmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.ParaBirimiKayitNo).HasColumnName("ParaBirimi_KayitNo");

                entity.Property(e => e.YargitayDosyaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DavaList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DavaList");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTuruKayitNo).HasColumnName("DavaTuru_KayitNo");

                entity.Property(e => e.DavaTuruTanim)
                    .HasColumnName("DavaTuru_Tanim")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Davaci)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirenKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirilmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DigerDavacilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavalilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IcraSafhasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KaldirmaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KararNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KararOzeti)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KararTarihi).HasColumnType("datetime");

                entity.Property(e => e.Mahkemesi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturanKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturulmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.ParaBirimiKayitNo).HasColumnName("ParaBirimi_KayitNo");

                entity.Property(e => e.ParaBirimiKodu)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SonucTarihi).HasColumnType("datetime");

                entity.Property(e => e.TemyizAciklamasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizTarihi).HasColumnType("datetime");

                entity.Property(e => e.YargitayDosyaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DavaListeleri>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DAVA_LISTELERI");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DavaAcilmaTuru)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DavaSonucu)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTuruTanim)
                    .HasColumnName("DavaTuru_Tanim")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Davaci)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirenKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DegistirilmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DigerDavacilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavalilar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IcraSafhasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KaldirmaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KararNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KararOzeti)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KararSonucu)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.KararTarihi).HasColumnType("datetime");

                entity.Property(e => e.Mahkemesi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturanKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturulmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.ParaBirimiKodu)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SonucTahmini)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SonucTarihi).HasColumnType("datetime");

                entity.Property(e => e.TemyizAciklamasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizDurumu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizEden)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizSonucu)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizTarihi).HasColumnType("datetime");

                entity.Property(e => e.YargitayDosyaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DavaSonucu>(entity =>
            {
                entity.HasKey(e => e.DavaKayitNo)
                    .HasName("PK_DavaSonuclari");

                entity.Property(e => e.DavaKayitNo)
                    .HasColumnName("Dava_KayitNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.DavaSonucu1).HasColumnName("DavaSonucu");

                entity.Property(e => e.IcraSafhasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KaldirmaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonucTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.DavaKayitNoNavigation)
                    .WithOne(p => p.DavaSonucu)
                    .HasForeignKey<DavaSonucu>(d => d.DavaKayitNo)
                    .HasConstraintName("FK_DavaSonucu_Dava");
            });

            modelBuilder.Entity<DavaTuru>(entity =>
            {
                entity.HasKey(e => e.KayitNo);

                entity.Property(e => e.Tanim)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EPetkimDavalarForm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("E_PetkimDavalar_Form");

                entity.Property(e => e.Aciklamasi)
                    .HasMaxLength(7500)
                    .IsUnicode(false);

                entity.Property(e => e.AleyheDavaninDegeri).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DavaAy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaGun)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaOzeti)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaSonucuTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DavaTurleri)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTurleriText)
                    .HasColumnName("DavaTurleri_TEXT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DavaVekili)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaYil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davaci)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DavaciVekili)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Davali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavacilar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavali)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DigerDavalilar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fdate)
                    .HasColumnName("FDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flow)
                    .HasColumnName("FLOW")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Followstatus).HasColumnName("FOLLOWSTATUS");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IslahDegeri).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KaldirmaNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KararNumarasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KararTarihi).HasColumnType("datetime");

                entity.Property(e => e.KararinOzeti)
                    .HasMaxLength(7500)
                    .IsUnicode(false);

                entity.Property(e => e.Lastchange)
                    .HasColumnName("LASTCHANGE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeheDavaninDegeri).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Linkdesc)
                    .HasColumnName("LINKDESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MahkemeAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MahkemeTipi)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MahkemeTipiText)
                    .HasColumnName("MahkemeTipi_TEXT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Metin1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Metin2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Processlink)
                    .HasColumnName("PROCESSLINK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ruser)
                    .HasColumnName("RUSER")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sonuc)
                    .HasColumnName("sonuc")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SonucText)
                    .HasColumnName("sonuc_TEXT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.TemyizAciklamasi)
                    .HasMaxLength(7500)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizNumarasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizTarihi).HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("VERSION");

                entity.Property(e => e.YeniDavaOzeti)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EPetkimDavalarFormSonuc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("E_PetkimDavalar_Form_sonuc");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Text)
                    .HasColumnName("TEXT")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Esleme>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Esleme");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Aciklamax)
                    .HasColumnName("ACIKLAMAx")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dkn).HasColumnName("DKN");

                entity.Property(e => e.Dsn)
                    .HasColumnName("DSN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.En)
                    .HasColumnName("EN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Konux)
                    .HasColumnName("KONUx")
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KolonIsimleri>(entity =>
            {
                entity.HasKey(e => new { e.TabloAdi, e.KolonAdi });

                entity.Property(e => e.TabloAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KolonAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KolonTakmaAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<OdemeBilgileriView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ODEME_BILGILERI_VIEW");

                entity.Property(e => e.DavaKayitNo).HasColumnName("Dava_KayitNo");

                entity.Property(e => e.DavaKonusu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DavaTarihi).HasColumnType("datetime");

                entity.Property(e => e.DefterSiraNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EsasNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IcraSafhasi)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KaldirmaNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonucTarihi).HasColumnType("datetime");

                entity.Property(e => e.Toplam).HasColumnName("TOPLAM");
            });

            modelBuilder.Entity<ParaBirimi>(entity =>
            {
                entity.HasKey(e => e.KayitNo)
                    .HasName("PK_ParaBirimleri");

                entity.Property(e => e.ParaBirimiKodu)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Tanimi)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Temyiz>(entity =>
            {
                entity.HasKey(e => e.DavaKayitNo);

                entity.Property(e => e.DavaKayitNo)
                    .HasColumnName("Dava_KayitNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TemyizTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.DavaKayitNoNavigation)
                    .WithOne(p => p.Temyiz)
                    .HasForeignKey<Temyiz>(d => d.DavaKayitNo)
                    .HasConstraintName("FK_Temyiz_Dava");
            });

            modelBuilder.Entity<YerelMahkemeKarari>(entity =>
            {
                entity.HasKey(e => e.DavaKayitNo);

                entity.Property(e => e.DavaKayitNo)
                    .HasColumnName("Dava_KayitNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.KararNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KararOzeti)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.KararTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.DavaKayitNoNavigation)
                    .WithOne(p => p.YerelMahkemeKarari)
                    .HasForeignKey<YerelMahkemeKarari>(d => d.DavaKayitNo)
                    .HasConstraintName("FK_YerelMahkemeKarari_Dava");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
