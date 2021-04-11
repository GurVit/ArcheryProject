namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Участник
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Участник()
        {
            История_получения_разряда = new HashSet<История_получения_разряда>();
            Участник_у_тренера = new HashSet<Участник_у_тренера>();
        }

        [Key]
        [Column("ID участника")]
        public Guid ID_участника { get; set; }

        [Required]
        [StringLength(30)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(30)]
        public string Имя { get; set; }

        [StringLength(30)]
        public string Отчество { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<История_получения_разряда> История_получения_разряда { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Участник_у_тренера> Участник_у_тренера { get; set; }

        public string? ФИО
        {
            get { return string.Format("{0} {1} {2}", Фамилия, Имя, Отчество); }
        }
    }
}
