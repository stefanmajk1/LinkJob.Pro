namespace agencija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Outbox")]
    public partial class Outbox
    {
        [Key]
        public int idOutBox { get; set; }

        [Required]
        [StringLength(50)]
        public string senderEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string senderName { get; set; }

        [Required]
        [StringLength(50)]
        public string recepientEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string subject { get; set; }

        [Required]
        public string body { get; set; }

        public bool isHtml { get; set; }

        [Column(TypeName = "date")]
        public DateTime sreatedAt { get; set; }

        public bool isSEnt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sentAt { get; set; }

        public int IdKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
