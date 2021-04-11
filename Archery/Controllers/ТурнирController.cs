using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Archery.Models;

namespace Курсовой_проект.Controllers
{
    [Authorize]
    public class ТурнирController : Controller
    {
        private ArcheryContext db = new ArcheryContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Турнир> турнир = db.Турнир.ToList();
            return View(турнир);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Турнир турнир = db.Турнир.FirstOrDefault(w => w.ID_турнира == id);
            Дисциплина_в_турнире дисциплина = db.Дисциплина_в_турнире.ToList().OrderBy(q => q.Код_дивизиона).FirstOrDefault(w => w.ID_турнира == id);
            if (турнир == null)
            {
                return HttpNotFound();
            }
            ViewBag.TurnirID = id;
            ViewBag.TurnirName = турнир.Наименование;
            ViewBag.TurnirYear = турнир.Год_проведения;
            return View(турнир);
        }

        public ActionResult DisciplinaDetails(bool? id1, int? id2, int? id3, Guid? id4)
        {
            if (id1 == null | id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Дисциплина_в_турнире дисциплина = db.Дисциплина_в_турнире.FirstOrDefault(q => q.Мужчины_женщины == id1 && q.Код_дивизиона == id2 && q.Код_дистанции == id3 && q.ID_турнира == id4);
            ViewBag.Gender = дисциплина.Мужчины_женщины;
            if (дисциплина == null)
            {
                return HttpNotFound();
            }
            return View(дисциплина);
        }

        public ActionResult Results(bool? id1, int? id2, int? id3, Guid? id4, Guid? id5)
        {
            if (id1 == null | id2 == null | id3 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участник_в_дисциплине_турнира участники = db.Участник_в_дисциплине_турнира
                .FirstOrDefault(q => q.Мужчины_женщины == id1 && q.Код_дивизиона == id2 && q.Код_дистанции == id3 && q.ID_турнира == id4 && q.ID_участника == id5);
            ViewBag.Результат = участники.Результат_стрельбы_У_в_серии_Д.Sum(q => q.Количество_очков);
            ViewBag.Gender = участники.Мужчины_женщины;
            if (участники == null)
            {
                return HttpNotFound();
            }
            return View(участники);
        }

        public ActionResult DisciplinaCreate(Guid? id)
        {
            ViewBag.Код_дивизиона = new SelectList(db.Дивизион, "Код_дивизиона", "Наименование");
            ViewBag.Мужчины_женщины = new SelectList(db.Дисциплина, "Мужчины_женщины");
            ViewBag.Код_дистанции = new SelectList(db.Дистанция, "Код_дистанции", "Дистанция__м");
            ViewBag.ID_судьи = new SelectList(db.Судья, "ID_судьи", "ФИО");
            ViewBag.TurnirID = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisciplinaCreate([Bind(Include = "Мужчины_женщины,Код_дивизиона,Код_дистанции,ID_турнира,ID_судьи,Дата_проведения")] Дисциплина_в_турнире дисциплина, Guid? id)
        {
            дисциплина.ID_турнира = (Guid)id;
            дисциплина.Дисциплина = db.Дисциплина.FirstOrDefault(q => q.Код_дивизиона == дисциплина.Код_дивизиона && q.Код_дистанции == дисциплина.Код_дистанции);
            дисциплина.Судья = db.Судья.FirstOrDefault(q => q.ID_судьи == дисциплина.ID_судьи);
            дисциплина.Турнир = db.Турнир.FirstOrDefault(q => q.ID_турнира == id);
            try
            {
                if (ModelState.IsValid)
                {
                    db.Дисциплина_в_турнире.Add(дисциплина);
                    db.SaveChanges();
                    return RedirectToActionPermanent("Details", new { id });
                }

                ViewBag.Код_дивизиона = new SelectList(db.Дивизион, "Код_дивизиона", "Наименование", дисциплина.Код_дивизиона);
                ViewBag.Код_дистанции = new SelectList(db.Дистанция, "Код_дистанции", "Дистанция__м", дисциплина.Код_дистанции);
                ViewBag.ID_судьи = new SelectList(db.Судья, "ID_судьи", "Фамилия", дисциплина.ID_судьи);
            }
            catch
            {
            }

            //ViewBag.Код_дивизиона = new SelectList(db.Дивизион, "Код_дивизиона", "Наименование", дисциплина.Код_дивизиона);
            //ViewBag.Код_дистанции = new SelectList(db.Дистанция, "Код_дистанции", "Дистанция__м", дисциплина.Код_дистанции);
            //ViewBag.ID_судьи = new SelectList(db.Судья, "ID_судьи", "Фамилия", дисциплина.ID_судьи);
            return RedirectToActionPermanent("Details", new { id });
        }
    }
}
