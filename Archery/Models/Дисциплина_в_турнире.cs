namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Дисциплина в турнире")]
    public partial class Дисциплина_в_турнире
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дисциплина_в_турнире()
        {
            Участник_в_дисциплине_турнира = new HashSet<Участник_в_дисциплине_турнира>();
        }

        [Key]
        [Column("Мужчины/женщины", Order = 0)]
        public bool Мужчины_женщины { get; set; }

        [Key]
        [Column("Код дивизиона", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дивизиона { get; set; }

        [Key]
        [Column("Код дистанции", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дистанции { get; set; }

        [Key]
        [Column("ID турнира", Order = 3)]
        public Guid ID_турнира { get; set; }

        [Column("ID судьи")]
        public Guid ID_судьи { get; set; }

        [Column("Дата проведения", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Дата_проведения { get; set; }

        public virtual Дисциплина Дисциплина { get; set; }

        public virtual Судья Судья { get; set; }

        public virtual Турнир Турнир { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Участник_в_дисциплине_турнира> Участник_в_дисциплине_турнира { get; set; }
    }
}
