namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OmiljeniOglasi")]
    public partial class OmiljeniOglasi
    {
        [Key]
        public int IdOmiljeniOglasi { get; set; }

        public int OglasId { get; set; }

        public int KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Ogla Ogla { get; set; }
    }
}
