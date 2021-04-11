namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pobeditel",
                c => new
                    {
                        Фамилия = c.String(nullable: false, maxLength: 30, unicode: false),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                        Отчество = c.String(maxLength: 30, unicode: false),
                        Количествопобед = c.Int(name: "Количество побед"),
                    })
                .PrimaryKey(t => new { t.Фамилия, t.Имя });
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.tezki",
                c => new
                    {
                        Фамилия = c.String(nullable: false, maxLength: 30, unicode: false),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => new { t.Фамилия, t.Имя });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, fixedLength: true),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Дивизион",
                c => new
                    {
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Коддивизиона);
            
            CreateTable(
                "dbo.Дисциплина",
                c => new
                    {
                        Мужчиныженщины = c.Boolean(name: "Мужчины/женщины", nullable: false),
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                    })
                .PrimaryKey(t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции })
                .ForeignKey("dbo.Дивизион", t => t.Коддивизиона, cascadeDelete: true)
                .ForeignKey("dbo.Дистанция", t => t.Коддистанции, cascadeDelete: true)
                .Index(t => t.Коддивизиона)
                .Index(t => t.Коддистанции);
            
            CreateTable(
                "dbo.Дистанция",
                c => new
                    {
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                        Дистанциям = c.Int(name: "Дистанция, м", nullable: false),
                    })
                .PrimaryKey(t => t.Коддистанции);
            
            CreateTable(
                "dbo.Дисциплина в турнире",
                c => new
                    {
                        Мужчиныженщины = c.Boolean(name: "Мужчины/женщины", nullable: false),
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                        IDтурнира = c.Guid(name: "ID турнира", nullable: false),
                        IDсудьи = c.Guid(name: "ID судьи", nullable: false),
                        Датапроведения = c.DateTime(name: "Дата проведения", nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира })
                .ForeignKey("dbo.Судья", t => t.IDсудьи, cascadeDelete: true)
                .ForeignKey("dbo.Турнир", t => t.IDтурнира, cascadeDelete: true)
                .ForeignKey("dbo.Дисциплина", t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции }, cascadeDelete: true)
                .Index(t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции })
                .Index(t => t.IDтурнира)
                .Index(t => t.IDсудьи);
            
            CreateTable(
                "dbo.Судья",
                c => new
                    {
                        IDсудьи = c.Guid(name: "ID судьи", nullable: false),
                        Фамилия = c.String(nullable: false, maxLength: 30, unicode: false),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                        Отчество = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDсудьи);
            
            CreateTable(
                "dbo.Турнир",
                c => new
                    {
                        IDтурнира = c.Guid(name: "ID турнира", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 30, unicode: false),
                        Годпроведения = c.Long(name: "Год проведения", nullable: false),
                    })
                .PrimaryKey(t => t.IDтурнира);
            
            CreateTable(
                "dbo.Участник в дисциплине турнира",
                c => new
                    {
                        IDтренера = c.Guid(name: "ID тренера", nullable: false),
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Мужчиныженщины = c.Boolean(name: "Мужчины/женщины", nullable: false),
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                        IDтурнира = c.Guid(name: "ID турнира", nullable: false),
                    })
                .PrimaryKey(t => new { t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира })
                .ForeignKey("dbo.Участник у тренера", t => new { t.IDтренера, t.IDучастника }, cascadeDelete: true)
                .ForeignKey("dbo.Дисциплина в турнире", t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира }, cascadeDelete: true)
                .Index(t => new { t.IDтренера, t.IDучастника })
                .Index(t => new { t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира });
            
            CreateTable(
                "dbo.Нарушение",
                c => new
                    {
                        Датанарушения = c.DateTime(name: "Дата нарушения", nullable: false, storeType: "date"),
                        IDтренера = c.Guid(name: "ID тренера", nullable: false),
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Мужчиныженщины = c.Boolean(name: "Мужчины/женщины", nullable: false),
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                        IDтурнира = c.Guid(name: "ID турнира", nullable: false),
                        Дисквалификация = c.Boolean(nullable: false),
                        Описание = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => new { t.Датанарушения, t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира })
                .ForeignKey("dbo.Участник в дисциплине турнира", t => new { t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира }, cascadeDelete: true)
                .Index(t => new { t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира });
            
            CreateTable(
                "dbo.Результат стрельбы У в серии Д",
                c => new
                    {
                        Серия = c.Int(nullable: false),
                        Номерстрелы = c.Int(name: "Номер стрелы", nullable: false),
                        IDтренера = c.Guid(name: "ID тренера", nullable: false),
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Мужчиныженщины = c.Boolean(name: "Мужчины/женщины", nullable: false),
                        Коддивизиона = c.Int(name: "Код дивизиона", nullable: false),
                        Коддистанции = c.Int(name: "Код дистанции", nullable: false),
                        IDтурнира = c.Guid(name: "ID турнира", nullable: false),
                        Количествоочков = c.Int(name: "Количество очков", nullable: false),
                    })
                .PrimaryKey(t => new { t.Серия, t.Номерстрелы, t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира })
                .ForeignKey("dbo.Участник в дисциплине турнира", t => new { t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира }, cascadeDelete: true)
                .Index(t => new { t.IDтренера, t.IDучастника, t.Мужчиныженщины, t.Коддивизиона, t.Коддистанции, t.IDтурнира });
            
            CreateTable(
                "dbo.Участник у тренера",
                c => new
                    {
                        IDтренера = c.Guid(name: "ID тренера", nullable: false),
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Датаприхода = c.DateTime(name: "Дата прихода", nullable: false, storeType: "date"),
                        Датаухода = c.DateTime(name: "Дата ухода", storeType: "date"),
                    })
                .PrimaryKey(t => new { t.IDтренера, t.IDучастника })
                .ForeignKey("dbo.Тренер", t => t.IDтренера, cascadeDelete: true)
                .ForeignKey("dbo.Участник", t => t.IDучастника, cascadeDelete: true)
                .Index(t => t.IDтренера)
                .Index(t => t.IDучастника);
            
            CreateTable(
                "dbo.Тренер",
                c => new
                    {
                        IDтренера = c.Guid(name: "ID тренера", nullable: false),
                        Фамилия = c.String(nullable: false, maxLength: 30, unicode: false),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                        Отчество = c.String(maxLength: 30, unicode: false),
                        IDклуба = c.Guid(name: "ID клуба", nullable: false),
                        Кодзвания = c.Int(name: "Код звания", nullable: false),
                    })
                .PrimaryKey(t => t.IDтренера)
                .ForeignKey("dbo.Клуб", t => t.IDклуба, cascadeDelete: true)
                .ForeignKey("dbo.Тренерское звание", t => t.Кодзвания, cascadeDelete: true)
                .Index(t => t.IDклуба)
                .Index(t => t.Кодзвания);
            
            CreateTable(
                "dbo.Клуб",
                c => new
                    {
                        IDклуба = c.Guid(name: "ID клуба", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDклуба);
            
            CreateTable(
                "dbo.Тренерское звание",
                c => new
                    {
                        Кодзвания = c.Int(name: "Код звания", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Кодзвания);
            
            CreateTable(
                "dbo.Участник",
                c => new
                    {
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Фамилия = c.String(nullable: false, maxLength: 30, unicode: false),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                        Отчество = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDучастника);
            
            CreateTable(
                "dbo.История получения разряда",
                c => new
                    {
                        Кодразряда = c.Int(name: "Код разряда", nullable: false),
                        IDучастника = c.Guid(name: "ID участника", nullable: false),
                        Датаполучения = c.DateTime(name: "Дата получения", nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => new { t.Кодразряда, t.IDучастника })
                .ForeignKey("dbo.Спортивный разряд", t => t.Кодразряда, cascadeDelete: true)
                .ForeignKey("dbo.Участник", t => t.IDучастника, cascadeDelete: true)
                .Index(t => t.Кодразряда)
                .Index(t => t.IDучастника);
            
            CreateTable(
                "dbo.Спортивный разряд",
                c => new
                    {
                        Кодразряда = c.Int(name: "Код разряда", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Кодразряда);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Дисциплина в турнире", new[] { "Мужчины/женщины", "Код дивизиона", "Код дистанции" }, "dbo.Дисциплина");
            DropForeignKey("dbo.Участник в дисциплине турнира", new[] { "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" }, "dbo.Дисциплина в турнире");
            DropForeignKey("dbo.Участник в дисциплине турнира", new[] { "ID тренера", "ID участника" }, "dbo.Участник у тренера");
            DropForeignKey("dbo.Участник у тренера", "ID участника", "dbo.Участник");
            DropForeignKey("dbo.История получения разряда", "ID участника", "dbo.Участник");
            DropForeignKey("dbo.История получения разряда", "Код разряда", "dbo.Спортивный разряд");
            DropForeignKey("dbo.Участник у тренера", "ID тренера", "dbo.Тренер");
            DropForeignKey("dbo.Тренер", "Код звания", "dbo.Тренерское звание");
            DropForeignKey("dbo.Тренер", "ID клуба", "dbo.Клуб");
            DropForeignKey("dbo.Результат стрельбы У в серии Д", new[] { "ID тренера", "ID участника", "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" }, "dbo.Участник в дисциплине турнира");
            DropForeignKey("dbo.Нарушение", new[] { "ID тренера", "ID участника", "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" }, "dbo.Участник в дисциплине турнира");
            DropForeignKey("dbo.Дисциплина в турнире", "ID турнира", "dbo.Турнир");
            DropForeignKey("dbo.Дисциплина в турнире", "ID судьи", "dbo.Судья");
            DropForeignKey("dbo.Дисциплина", "Код дистанции", "dbo.Дистанция");
            DropForeignKey("dbo.Дисциплина", "Код дивизиона", "dbo.Дивизион");
            DropIndex("dbo.История получения разряда", new[] { "ID участника" });
            DropIndex("dbo.История получения разряда", new[] { "Код разряда" });
            DropIndex("dbo.Тренер", new[] { "Код звания" });
            DropIndex("dbo.Тренер", new[] { "ID клуба" });
            DropIndex("dbo.Участник у тренера", new[] { "ID участника" });
            DropIndex("dbo.Участник у тренера", new[] { "ID тренера" });
            DropIndex("dbo.Результат стрельбы У в серии Д", new[] { "ID тренера", "ID участника", "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" });
            DropIndex("dbo.Нарушение", new[] { "ID тренера", "ID участника", "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" });
            DropIndex("dbo.Участник в дисциплине турнира", new[] { "Мужчины/женщины", "Код дивизиона", "Код дистанции", "ID турнира" });
            DropIndex("dbo.Участник в дисциплине турнира", new[] { "ID тренера", "ID участника" });
            DropIndex("dbo.Дисциплина в турнире", new[] { "ID судьи" });
            DropIndex("dbo.Дисциплина в турнире", new[] { "ID турнира" });
            DropIndex("dbo.Дисциплина в турнире", new[] { "Мужчины/женщины", "Код дивизиона", "Код дистанции" });
            DropIndex("dbo.Дисциплина", new[] { "Код дистанции" });
            DropIndex("dbo.Дисциплина", new[] { "Код дивизиона" });
            DropTable("dbo.Спортивный разряд");
            DropTable("dbo.История получения разряда");
            DropTable("dbo.Участник");
            DropTable("dbo.Тренерское звание");
            DropTable("dbo.Клуб");
            DropTable("dbo.Тренер");
            DropTable("dbo.Участник у тренера");
            DropTable("dbo.Результат стрельбы У в серии Д");
            DropTable("dbo.Нарушение");
            DropTable("dbo.Участник в дисциплине турнира");
            DropTable("dbo.Турнир");
            DropTable("dbo.Судья");
            DropTable("dbo.Дисциплина в турнире");
            DropTable("dbo.Дистанция");
            DropTable("dbo.Дисциплина");
            DropTable("dbo.Дивизион");
            DropTable("dbo.User");
            DropTable("dbo.tezki");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.pobeditel");
        }
    }
}
