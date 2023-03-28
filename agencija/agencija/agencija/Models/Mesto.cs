namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesto")]
    public partial class Mesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mesto()
        {
            Oglas = new HashSet<Ogla>();
        }

        [Key]
        public int idMesto { get; set; }

        [Required]
        [StringLength(50)]
        public string naziv { get; set; }

        public int postanskiBroj { get; set; }

        public int drzavaID { get; set; }

        public virtual Drzava Drzava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogla> Oglas { get; set; }
    }
}
