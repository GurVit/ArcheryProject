namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Тренерское звание")]
    public partial class Тренерское_звание
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тренерское_звание()
        {
            Тренер = new HashSet<Тренер>();
        }

        [Key]
        [Column("Код звания")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_звания { get; set; }

        [Required]
        [StringLength(50)]
        public string Наименование { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Тренер> Тренер { get; set; }
    }
}
