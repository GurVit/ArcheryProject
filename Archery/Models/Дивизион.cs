namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Дивизион
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дивизион()
        {
            Дисциплина = new HashSet<Дисциплина>();
        }

        [Key]
        [Column("Код дивизиона")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дивизиона { get; set; }

        [Required]
        [StringLength(30)]
        public string Наименование { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дисциплина> Дисциплина { get; set; }
    }
}
