namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Спортивный разряд")]
    public partial class Спортивный_разряд
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Спортивный_разряд()
        {
            История_получения_разряда = new HashSet<История_получения_разряда>();
        }

        [Key]
        [Column("Код разряда")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_разряда { get; set; }

        [Required]
        [StringLength(30)]
        public string Наименование { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<История_получения_разряда> История_получения_разряда { get; set; }
    }
}
