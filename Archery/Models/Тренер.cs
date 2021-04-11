namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Тренер
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тренер()
        {
            Участник_у_тренера = new HashSet<Участник_у_тренера>();
        }

        [Key]
        [Column("ID тренера")]
        public Guid ID_тренера { get; set; }

        [Required]
        [StringLength(30)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(30)]
        public string Имя { get; set; }

        [StringLength(30)]
        public string Отчество { get; set; }

        [Column("ID клуба")]
        public Guid ID_клуба { get; set; }

        [Column("Код звания")]
        public int Код_звания { get; set; }

        public virtual Клуб Клуб { get; set; }

        public virtual Тренерское_звание Тренерское_звание { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Участник_у_тренера> Участник_у_тренера { get; set; }

        public string? ФИО
        {
            get { return string.Format("{0} {1} {2}", Фамилия, Имя, Отчество); }
        }
    }
}
