using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace agencija.Models
{
    public class VirtualObjavaOglasa
    {
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

       

        public virtual Iskustvo Iskustvo { get; set; }

       

        public virtual Kategorija Kategorija { get; set; }

        public virtual Kompanija Kompanija { get; set; }

        public virtual Mesto Mesto { get; set; }

        public int KLJUCKOMPANIJE { get; set; }
        [Key]
        public int idCenovnikUplataOglasa { get; set; }
        public int oglasi { get; set; }


    }
}