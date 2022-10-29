using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencija.ViewModel
{
    public class OglasViewModel
    {
        public int idOglas { get; set; }
        public DateTime Istice { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public int Poseta { get; set; }
        public int KategorijaID { get; set; }
        public int MestoId { get; set; }
        public int IdIskustvo { get; set; }
        public int IdKompanija { get; set; }

    }
}