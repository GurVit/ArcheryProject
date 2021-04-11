namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Судья
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Судья()
        {
            Дисциплина_в_турнире = new HashSet<Дисциплина_в_турнире>();
        }

        [Key]
        [Column("ID судьи")]
        public Guid ID_судьи { get; set; }

        [Required]
        [StringLength(30)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(30)]
        public string Имя { get; set; }

        [StringLength(30)]
        public string Отчество { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дисциплина_в_турнире> Дисциплина_в_турнире { get; set; }

        public string? ФИО
        {
            get { return string.Format("{0} {1} {2}", Фамилия, Имя, Отчество); }
        }
    }
}
