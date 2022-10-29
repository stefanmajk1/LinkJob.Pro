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
        public int IdOmiljeniOglas { get; set; }

        public int IdOglas { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dodat { get; set; }

        public int Kolicina { get; set; }

        public virtual Ogla Ogla { get; set; }
    }
}
