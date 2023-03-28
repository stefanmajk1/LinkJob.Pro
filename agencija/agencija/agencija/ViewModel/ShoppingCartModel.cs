using agencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencija.ViewModel
{
    public class ShoppingCartModel
    {
        public int idOglas { get; set; }
        public DateTime Istice { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public string Mesto { get; set; }

        public string Iskustvo { get; set; }
        public string Kompanija { get; set; }
        public string Kategorija { get; set; }
        public int Quantity { get; set; }

       
    }
}