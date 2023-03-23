using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencija.Models
{
    public class ViewAdModel
    {
        public int AdId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsLiked { get; set; }

        public DateTime Istice { get; set; }

        public int? Poseta { get; set; }

        public int IdKategorija { get; set; }
        public int IdMesto { get; set; }
        public int IdIskustvo { get; set; }
        public int IdKompanija { get; set; }

        public virtual Iskustvo Iskustvo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kandidat> Kandidats { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        public virtual Kompanija Kompanija { get; set; }

        public virtual Mesto Mesto { get; set; }
    }
}