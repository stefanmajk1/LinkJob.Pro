using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencija.Models
{
    public class VirtualKandidat
    {
        public int idOglas { get; set; }

        public HttpPostedFileBase propratniDokument { get; set; }

        public HttpPostedFileBase cv { get; set; }

        public int idUser { get; set; }

        [Key]
        public int idKandidat { get; set; }

        public bool? aktivanKandidat { get; set; }

        public virtual Ogla Ogla { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}