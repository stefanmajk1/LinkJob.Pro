using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace agencija.Models
{
    public partial class Agencija_Context : DbContext
    {
        public Agencija_Context()
            : base("name=Agencija_Context1")
        {
        }

        public virtual DbSet<CenovnikOglasa> CenovnikOglasas { get; set; }
        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Iskustvo> Iskustvoes { get; set; }
        public virtual DbSet<Kandidat> Kandidats { get; set; }
        public virtual DbSet<Kategorija> Kategorijas { get; set; }
        public virtual DbSet<Kompanija> Kompanijas { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Mesto> Mestoes { get; set; }
        public virtual DbSet<Ogla> Oglas { get; set; }
        public virtual DbSet<OmiljeniOglasi> OmiljeniOglasis { get; set; }
        public virtual DbSet<Outbox> Outboxes { get; set; }
        public virtual DbSet<Rola> Rolas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UplataOglasa> UplataOglasas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CenovnikOglasa>()
                .Property(e => e.istaknut)
                .IsFixedLength();

            modelBuilder.Entity<CenovnikOglasa>()
                .HasMany(e => e.UplataOglasas)
                .WithRequired(e => e.CenovnikOglasa)
                .HasForeignKey(e => e.idCenovnikOglasa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Mestoes)
                .WithRequired(e => e.Drzava)
                .HasForeignKey(e => e.drzavaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Iskustvo>()
                .HasMany(e => e.Oglas)
                .WithRequired(e => e.Iskustvo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidat>()
                .Property(e => e.fileTypePropratniDokument)
                .IsFixedLength();

            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.Oglas)
                .WithRequired(e => e.Kategorija)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kompanija>()
                .HasMany(e => e.Oglas)
                .WithRequired(e => e.Kompanija)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kompanija>()
                .HasMany(e => e.UplataOglasas)
                .WithRequired(e => e.Kompanija)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Kandidats)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Outboxes)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mesto>()
                .HasMany(e => e.Oglas)
                .WithRequired(e => e.Mesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ogla>()
                .HasMany(e => e.Kandidats)
                .WithRequired(e => e.Ogla)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ogla>()
                .HasMany(e => e.OmiljeniOglasis)
                .WithRequired(e => e.Ogla)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rola>()
                .HasMany(e => e.Korisniks)
                .WithRequired(e => e.Rola)
                .WillCascadeOnDelete(false);
        }
    }
}
