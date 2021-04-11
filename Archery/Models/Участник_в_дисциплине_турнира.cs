namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Участник в дисциплине турнира")]
    public partial class Участник_в_дисциплине_турнира
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Участник_в_дисциплине_турнира()
        {
            Нарушение = new HashSet<Нарушение>();
            Результат_стрельбы_У_в_серии_Д = new HashSet<Результат_стрельбы_У_в_серии_Д>();
        }

        [Key]
        [Column("ID тренера", Order = 0)]
        public Guid ID_тренера { get; set; }

        [Key]
        [Column("ID участника", Order = 1)]
        public Guid ID_участника { get; set; }

        [Key]
        [Column("Мужчины/женщины", Order = 2)]
        public bool Мужчины_женщины { get; set; }

        [Key]
        [Column("Код дивизиона", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дивизиона { get; set; }

        [Key]
        [Column("Код дистанции", Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дистанции { get; set; }

        [Key]
        [Column("ID турнира", Order = 5)]
        public Guid ID_турнира { get; set; }

        public virtual Дисциплина_в_турнире Дисциплина_в_турнире { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Нарушение> Нарушение { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Результат_стрельбы_У_в_серии_Д> Результат_стрельбы_У_в_серии_Д { get; set; }

        public virtual Участник_у_тренера Участник_у_тренера { get; set; }
    }
}
