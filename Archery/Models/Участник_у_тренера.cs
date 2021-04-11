namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Участник у тренера")]
    public partial class Участник_у_тренера
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Участник_у_тренера()
        {
            Участник_в_дисциплине_турнира = new HashSet<Участник_в_дисциплине_турнира>();
        }

        [Column("Дата прихода", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Дата_прихода { get; set; }

        [Column("Дата ухода", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Дата_ухода { get; set; }

        [Key]
        [Column("ID тренера", Order = 0)]
        public Guid ID_тренера { get; set; }

        [Key]
        [Column("ID участника", Order = 1)]
        public Guid ID_участника { get; set; }

        public virtual Тренер Тренер { get; set; }

        public virtual Участник Участник { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Участник_в_дисциплине_турнира> Участник_в_дисциплине_турнира { get; set; }
    }
}
