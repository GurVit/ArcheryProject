namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Турнир
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Турнир()
        {
            Дисциплина_в_турнире = new HashSet<Дисциплина_в_турнире>();
        }

        [Key]
        [Column("ID турнира")]
        public Guid ID_турнира { get; set; }

        [Required]
        [StringLength(30)]
        public string Наименование { get; set; }

        [Column("Год проведения")]
        public long Год_проведения { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дисциплина_в_турнире> Дисциплина_в_турнире { get; set; }
    }
}
