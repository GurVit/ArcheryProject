namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Дисциплина
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дисциплина()
        {
            Дисциплина_в_турнире = new HashSet<Дисциплина_в_турнире>();
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

        public virtual Дивизион Дивизион { get; set; }

        public virtual Дистанция Дистанция { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дисциплина_в_турнире> Дисциплина_в_турнире { get; set; }
    }
}
