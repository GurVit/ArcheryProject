namespace Archery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("История получения разряда")]
    public partial class История_получения_разряда
    {
        [Column("Дата получения", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Дата_получения { get; set; }

        [Key]
        [Column("Код разряда", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_разряда { get; set; }

        [Key]
        [Column("ID участника", Order = 1)]
        public Guid ID_участника { get; set; }

        public virtual Спортивный_разряд Спортивный_разряд { get; set; }

        public virtual Участник Участник { get; set; }
    }
}
