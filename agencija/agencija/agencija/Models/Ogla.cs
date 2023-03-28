namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ogla
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogla()
        {
            Kandidats = new HashSet<Kandidat>();
            OmiljeniOglasis = new HashSet<OmiljeniOglasi>();
        }

        [Key]
        public int idOglas { get; set; }

        [Column(TypeName = "date")]
        public DateTime istice { get; set; }

        [Required]
        [StringLength(50)]
        public string naslov { get; set; }

        [Required]
        public string opis { get; set; }

        public int? poseta { get; set; }

        public int idKategorija { get; set; }

        public int idMesto { get; set; }

        public int idIskustvo { get; set; }

        public int IdKompanija { get; set; }

        public bool? aktivanOglas { get; set; }

        public int? omiljen { get; set; }

        public virtual Iskustvo Iskustvo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kandidat> Kandidats { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        public virtual Kompanija Kompanija { get; set; }

        public virtual Mesto Mesto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OmiljeniOglasi> OmiljeniOglasis { get; set; }
    }
}
