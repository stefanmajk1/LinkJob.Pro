using agencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencija.Models
{
    public class OglasVezaSaKljucevima
    {
        public int idOglas { get; set; }

        public DateTime istice { get; set; }

        public string naslov { get; set; }

        public string opis { get; set; }

        public int? poseta { get; set; }

        public int kategorijaID { get; set; }

        public int mestoID { get; set; }

        public int idIskustvo { get; set; }

        public int IdKompanija { get; set; }

        public Mesto Mesto { get; set; }
        public Iskustvo Iskustvo { get; set; }
        public Kategorija Kategorija { get; set; }
        public Kompanija Kompanija { get; set; }
        public UplataOglasa UplataOglasa { get; set; }
    }
}