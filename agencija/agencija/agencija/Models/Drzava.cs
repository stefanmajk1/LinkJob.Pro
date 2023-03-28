namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drzava")]
    public partial class Drzava
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drzava()
        {
            Mestoes = new HashSet<Mesto>();
        }

        [Key]
        public int idDrzava { get; set; }

        [Required]
        [StringLength(50)]
        public string naziv { get; set; }

        [Required]
        [StringLength(50)]
        public string kod { get; set; }

        [Required]
        [StringLength(10)]
        public string telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesto> Mestoes { get; set; }
    }
}
