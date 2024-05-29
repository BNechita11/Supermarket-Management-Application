using Microsoft.EntityFrameworkCore;
using WpfApp3.Models;

namespace WpfApp3.DataBase
{
    public class MagazinContextDb : DbContext
    {
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Producator> Producator { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Stoc> Stoc { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }
        public DbSet<BonCasa> BonCasa { get; set; }
        public DbSet<BonCasaDetalii> BonCasaDetalii { get; set; }

        public DbSet<Vanzare> Vanzare { get; set; } 

        public MagazinContextDb(DbContextOptions<MagazinContextDb> options) : base(options)
        {
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=XXX;Database=MakeupBIAShopDatabase;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurați relațiile și cheile străine pentru modelul Produs
            modelBuilder.Entity<Produs>()
                .HasOne(p => p.Categorie)
                .WithMany()
                .HasForeignKey(p => p.CategorieId);

            modelBuilder.Entity<Produs>()
                .HasOne(p => p.Producator)
                .WithMany()
                .HasForeignKey(p => p.ProducatorId);

            // Configurați relațiile și cheile străine pentru modelul Stoc
            modelBuilder.Entity<Stoc>()
                .HasOne(s => s.Produs)
                .WithMany()
                .HasForeignKey(s => s.ProdusId);

            // Configurați relațiile și cheile străine pentru modelul BonCasa
            modelBuilder.Entity<BonCasa>()
                .HasOne(b => b.Casier)
                .WithMany()
                .HasForeignKey(b => b.CasierId);

            modelBuilder.Entity<BonCasaDetalii>()
                .HasOne(bd => bd.BonCasa)
                .WithMany(b => b.Detalii)
                .HasForeignKey(bd => bd.BonCasaId);

            modelBuilder.Entity<BonCasaDetalii>()
                .HasOne(bd => bd.Produs)
                .WithMany()
                .HasForeignKey(bd => bd.ProdusId);

            modelBuilder.Entity<BonCasaDetalii>()
                .Property(bd => bd.Cantitate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BonCasaDetalii>()
                .Property(bd => bd.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Stoc>()
                .Property(s => s.Cantitate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Stoc>()
                .Property(s => s.PretAchizitie)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BonCasaDetalii>()
               .Property(bd => bd.Cantitate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BonCasaDetalii>()
                .Property(bd => bd.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Stoc>()
                .Property(s => s.Cantitate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Stoc>()
                .Property(s => s.PretAchizitie)
                .HasColumnType("decimal(18,2)");

        }
    }
}
