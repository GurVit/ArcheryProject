namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pobeditel")]
    public partial class pobeditel
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Фамилия { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Имя { get; set; }

        [StringLength(30)]
        public string Отчество { get; set; }

        [Column("Количество побед")]
        public int? Количество_побед { get; set; }

        public string ФИО
        {
            get { return string.Format("{0} {1}", Фамилия, Имя); }
        }
    }
}
