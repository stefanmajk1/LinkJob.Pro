namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kandidat")]
    public partial class Kandidat
    {
        public int idOglas { get; set; }

        [StringLength(350)]
        public string propratniDokument { get; set; }

        [StringLength(350)]
        public string cv { get; set; }

        public int idUser { get; set; }

        [Key]
        public int idKandidat { get; set; }

        public bool? aktivanKandidat { get; set; }

        public virtual Ogla Ogla { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
