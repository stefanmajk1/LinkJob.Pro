namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kompanija")]
    public partial class Kompanija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kompanija()
        {
            Oglas = new HashSet<Ogla>();
            UplataOglasas = new HashSet<UplataOglasa>();
            Korisniks = new HashSet<Korisnik>();
        }

        [Key]
        public int IdKompanija { get; set; }

        public string video { get; set; }

        [Required]
        public string sajt { get; set; }

        [Required]
        public string opis { get; set; }

        [Required]
        [StringLength(50)]
        public string naziv { get; set; }

        public byte[] logo { get; set; }

        [Required]
        [StringLength(50)]
        public string adresa { get; set; }

        [Required]
        [StringLength(20)]
        public string telefon { get; set; }

        public int pib { get; set; }

        public bool? aktivnaKompanija { get; set; }

        [StringLength(10)]
        public string idOglas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogla> Oglas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UplataOglasa> UplataOglasas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
