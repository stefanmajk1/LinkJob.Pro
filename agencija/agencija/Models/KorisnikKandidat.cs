using agencija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencija.Models
{
    public class KorisnikKandidat
    {
        [Key]
        public int IdKorisnik { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(18)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifra { get; set; }

        public byte[] Slika { get; set; }

        public int idRola { get; set; }

        public int? idKompanija { get; set; }
        public Kandidat Kandidat { get; set; }
    }
}