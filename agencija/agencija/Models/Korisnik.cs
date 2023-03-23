namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            Kandidats = new HashSet<Kandidat>();
            OmiljeniOglasis = new HashSet<OmiljeniOglasi>();
            Outboxes = new HashSet<Outbox>();
        }

        [Key]
        public int IdKorisnik { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(18)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifra { get; set; }

        public byte[] Slika { get; set; }

        public int idRola { get; set; }

        public int? idKompanija { get; set; }

        public bool? aktivanKorisnik { get; set; }

        public string NazivSlike { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kandidat> Kandidats { get; set; }

        public virtual Kompanija Kompanija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OmiljeniOglasi> OmiljeniOglasis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outbox> Outboxes { get; set; }

        public virtual Rola Rola { get; set; }
    }
}
