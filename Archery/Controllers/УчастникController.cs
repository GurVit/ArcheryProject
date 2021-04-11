using Archery.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Archers.Controllers
{
    [Authorize]
    public class УчастникController : Controller
    {
        private ArcheryContext db = new ArcheryContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Участник.ToList().OrderBy(q => q.Фамилия));
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участник участники = db.Участник.FirstOrDefault(u => u.ID_участника == id);
            if (участники == null)
            {
                return HttpNotFound();
            }
            return View(участники);
        }

        public ActionResult Razryad(Guid? id)
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_участника,Фамилия,Имя,Отчество")] Участник участники)
        {
            участники.ID_участника = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                db.Участник.Add(участники);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(участники);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участник участники = db.Участник.Find(id);
            if (участники == null)
            {
                return HttpNotFound();
            }
            return View(участники);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_участника,Фамилия,Имя,Отчество")] Участник участники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(участники).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(участники);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участник участник = db.Участник.Find(id);
            if (участник == null)
            {
                return HttpNotFound();
            }
            return View(участник);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? id)
        {
            Участник участник = db.Участник.Find(id);
            db.Участник.Remove(участник);
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
