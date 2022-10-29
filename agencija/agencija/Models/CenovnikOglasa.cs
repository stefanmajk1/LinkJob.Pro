namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CenovnikOglasa")]
    public partial class CenovnikOglasa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CenovnikOglasa()
        {
            UplataOglasas = new HashSet<UplataOglasa>();
        }

        [Key]
        public int idCenovnik { get; set; }

        [Required]
        [StringLength(20)]
        public string paket { get; set; }

        public int brojOglasa { get; set; }

        [Required]
        [StringLength(20)]
        public string slika { get; set; }

        [Required]
        [StringLength(10)]
        public string istaknut { get; set; }

        public int vremenskiPeriod { get; set; }

        public bool aktivanCenovnik { get; set; }

        public int cena { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UplataOglasa> UplataOglasas { get; set; }
    }
}
