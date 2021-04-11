namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Дистанция
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дистанция()
        {
            Дисциплина = new HashSet<Дисциплина>();
        }

        [Key]
        [Column("Код дистанции")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_дистанции { get; set; }

        [Column("Дистанция, м")]
        public int Дистанция__м { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дисциплина> Дисциплина { get; set; }
    }
}
