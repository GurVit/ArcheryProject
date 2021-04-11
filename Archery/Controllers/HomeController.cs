using Archery.Models;
using System.Linq;
using System.Web.Mvc;

namespace Archer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ArcheryContext db = new ArcheryContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pobeditel()
        {
            return View(db.pobeditel.ToList());
        }

        public ActionResult tezki()
        {
            return View(db.tezki);
        }
    }
}