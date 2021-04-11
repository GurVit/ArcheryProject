namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Результат стрельбы У в серии Д")]
    public partial class Результат_стрельбы_У_в_серии_Д
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Серия { get; set; }

        [Key]
        [Column("Номер стрелы", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_стрелы { get; set; }

        [Column("Количество очков")]
        public int Количество_очков { get; set; }

        [Key]
        [Column("ID тренера", Order = 2)]
        public Guid ID_тренера { get; set; }

        [Key]
        [Column("ID участника", Order = 3)]
        public Guid ID_участника { get; set; }

        [Key]
        [Column("Мужчины/женщины", Order = 4)]
        public bool Мужчины_женщины { get; set; }

        [Key]
        [Column("Код дивизиона", Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дивизиона { get; set; }

        [Key]
        [Column("Код дистанции", Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дистанции { get; set; }

        [Key]
        [Column("ID турнира", Order = 7)]
        public Guid ID_турнира { get; set; }

        public virtual Участник_в_дисциплине_турнира Участник_в_дисциплине_турнира { get; set; }
    }
}
