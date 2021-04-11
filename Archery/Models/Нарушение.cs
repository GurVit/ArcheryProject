namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Нарушение
    {
        [Key]
        [Column("Дата нарушения", Order = 0, TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Дата_нарушения { get; set; }

        public bool Дисквалификация { get; set; }

        [Required]
        [StringLength(150)]
        public string Описание { get; set; }

        [Key]
        [Column("ID тренера", Order = 1)]
        public Guid ID_тренера { get; set; }

        [Key]
        [Column("ID участника", Order = 2)]
        public Guid ID_участника { get; set; }

        [Key]
        [Column("Мужчины/женщины", Order = 3)]
        public bool Мужчины_женщины { get; set; }

        [Key]
        [Column("Код дивизиона", Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дивизиона { get; set; }

        [Key]
        [Column("Код дистанции", Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дистанции { get; set; }

        [Key]
        [Column("ID турнира", Order = 6)]
        public Guid ID_турнира { get; set; }

        public virtual Участник_в_дисциплине_турнира Участник_в_дисциплине_турнира { get; set; }
    }
}
