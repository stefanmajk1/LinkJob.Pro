namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Kandidat")]
    public partial class Kandidat
    {
        public int idOglas { get; set; }

        public int? omiljeni { get; set; }

        public byte[] propratniDokument { get; set; }

        public byte[] cv { get; set; }

        public int idUser { get; set; }

        [Key]
        public int idKandidat { get; set; }

        [StringLength(50)]
        public string fileTypeCV { get; set; }

        [StringLength(50)]
        public string fileTypePropratniDokument { get; set; }

        public bool? aktivanKandidat { get; set; }

        public virtual Ogla Ogla { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}
