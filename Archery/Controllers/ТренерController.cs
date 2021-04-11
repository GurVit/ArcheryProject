using Archery.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Archers.Controllers
{
    [Authorize]
    public class ТренерController : Controller
    {
        private ArcheryContext db = new ArcheryContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Тренер.OrderBy(q => q.Фамилия));
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренеры = db.Тренер.Find(id);
            if (тренеры == null)
            {
                return HttpNotFound();
            }
            return View(тренеры);
        }

        public ActionResult UchastnikDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участник участник = db.Участник.Include(c => c.История_получения_разряда).FirstOrDefault(c => c.ID_участника == id);
            if (участник == null)
            {
                return HttpNotFound();
            }
            return View(участник);
        }

        public ActionResult Create()
        {
            ViewBag.ID_клуба = new SelectList(db.Клуб, "ID_клуба", "Наименование");
            ViewBag.Код_звания = new SelectList(db.Тренерское_звание, "Код_звания", "Наименование");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_тренера,Фамилия,Имя,Отчество,Код_звания,ID_клуба")] Тренер тренеры)
        {
            тренеры.ID_тренера = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                db.Тренер.Add(тренеры);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_клуба = new SelectList(db.Клуб, "ID_клуба", "Наименование", тренеры.ID_клуба);
            ViewBag.Код_звания = new SelectList(db.Тренерское_звание, "Код_звания", "Наименование", тренеры.Код_звания);
            return RedirectToAction("");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренеры = db.Тренер.Find(id);
            if (тренеры == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_клуба = new SelectList(db.Клуб, "ID_клуба", "Наименование", тренеры.ID_клуба);
            ViewBag.Код_звания = new SelectList(db.Тренерское_звание, "Код_звания", "Наименование", тренеры.Код_звания);
            return View(тренеры);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_тренера,Фамилия,Имя,Отчество,Код_звания,ID_клуба")] Тренер тренеры)
        {
            if (ModelState.IsValid)
            {
                db.Entry(тренеры).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_клуба = new SelectList(db.Клуб, "ID_клуба", "Наименование", тренеры.ID_клуба);
            ViewBag.Код_звания = new SelectList(db.Тренерское_звание, "Код_звания", "Наименование", тренеры.Код_звания);
            return View(тренеры);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренер = db.Тренер.Find(id);
            if (тренер == null)
            {
                return HttpNotFound();
            }
            return View(тренер);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            Тренер тренер = db.Тренер.Find(id);
            db.Тренер.Remove(тренер);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
