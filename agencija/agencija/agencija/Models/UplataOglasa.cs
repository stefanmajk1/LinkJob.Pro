namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UplataOglasa")]
    public partial class UplataOglasa
    {
        public int idKompanija { get; set; }

        [Key]
        public int idCenovnikUplataOglasa { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumUplate { get; set; }

        public int idCenovnikOglasa { get; set; }

        public int cena { get; set; }

        public int oglasi { get; set; }

        public virtual CenovnikOglasa CenovnikOglasa { get; set; }

        public virtual Kompanija Kompanija { get; set; }
    }
}
