namespace Archery.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArcheryContext : DbContext
    {
        public ArcheryContext()
            : base("name=ArcheryContext")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Дивизион> Дивизион { get; set; }
        public virtual DbSet<Дистанция> Дистанция { get; set; }
        public virtual DbSet<Дисциплина> Дисциплина { get; set; }
        public virtual DbSet<Дисциплина_в_турнире> Дисциплина_в_турнире { get; set; }
        public virtual DbSet<История_получения_разряда> История_получения_разряда { get; set; }
        public virtual DbSet<Клуб> Клуб { get; set; }
        public virtual DbSet<Нарушение> Нарушение { get; set; }
        public virtual DbSet<Результат_стрельбы_У_в_серии_Д> Результат_стрельбы_У_в_серии_Д { get; set; }
        public virtual DbSet<Спортивный_разряд> Спортивный_разряд { get; set; }
        public virtual DbSet<Судья> Судья { get; set; }
        public virtual DbSet<Тренер> Тренер { get; set; }
        public virtual DbSet<Тренерское_звание> Тренерское_звание { get; set; }
        public virtual DbSet<Турнир> Турнир { get; set; }
        public virtual DbSet<Участник> Участник { get; set; }
        public virtual DbSet<Участник_в_дисциплине_турнира> Участник_в_дисциплине_турнира { get; set; }
        public virtual DbSet<Участник_у_тренера> Участник_у_тренера { get; set; }
        public virtual DbSet<pobeditel> pobeditel { get; set; }
        public virtual DbSet<tezki> tezki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Дивизион>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Дисциплина>()
                .HasMany(e => e.Дисциплина_в_турнире)
                .WithRequired(e => e.Дисциплина)
                .HasForeignKey(e => new { e.Мужчины_женщины, e.Код_дивизиона, e.Код_дистанции });

            modelBuilder.Entity<Дисциплина_в_турнире>()
                .HasMany(e => e.Участник_в_дисциплине_турнира)
                .WithRequired(e => e.Дисциплина_в_турнире)
                .HasForeignKey(e => new { e.Мужчины_женщины, e.Код_дивизиона, e.Код_дистанции, e.ID_турнира });

            modelBuilder.Entity<Клуб>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Нарушение>()
                .Property(e => e.Описание)
                .IsUnicode(false);

            modelBuilder.Entity<Спортивный_разряд>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Судья>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<Судья>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Судья>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Тренер>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<Тренер>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Тренер>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Тренерское_звание>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Турнир>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Участник>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<Участник>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Участник>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Участник_в_дисциплине_турнира>()
                .HasMany(e => e.Нарушение)
                .WithRequired(e => e.Участник_в_дисциплине_турнира)
                .HasForeignKey(e => new { e.ID_тренера, e.ID_участника, e.Мужчины_женщины, e.Код_дивизиона, e.Код_дистанции, e.ID_турнира });

            modelBuilder.Entity<Участник_в_дисциплине_турнира>()
                .HasMany(e => e.Результат_стрельбы_У_в_серии_Д)
                .WithRequired(e => e.Участник_в_дисциплине_турнира)
                .HasForeignKey(e => new { e.ID_тренера, e.ID_участника, e.Мужчины_женщины, e.Код_дивизиона, e.Код_дистанции, e.ID_турнира });

            modelBuilder.Entity<Участник_у_тренера>()
                .HasMany(e => e.Участник_в_дисциплине_турнира)
                .WithRequired(e => e.Участник_у_тренера)
                .HasForeignKey(e => new { e.ID_тренера, e.ID_участника });

            modelBuilder.Entity<pobeditel>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<pobeditel>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<pobeditel>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<tezki>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<tezki>()
                .Property(e => e.Имя)
                .IsUnicode(false);
        }
    }
}
