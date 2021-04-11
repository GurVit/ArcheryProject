using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using Archery.Models;

namespace FormsAuthApp.Controllers
{
    public class AccountController : Controller
    {
        private string SetPassword(string userPassword)
        {
            string pwdToHash = userPassword + "^Y8~JJ"; // ^Y8~JJ - соль
            string salt = "$2a$10$go9fab0I48HDrjSbQbpqvu";
            string hashToStoreInDatabase = BCrypt.Net.BCrypt.HashPassword(pwdToHash, salt);
            return hashToStoreInDatabase;
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                bool CheckPass = false;
                using (ArcheryContext db = new ArcheryContext())
                {
                    user = db.User.FirstOrDefault(u => u.Email == model.Name);
                    string trimmedPass = user.Password.Trim();
                    CheckPass = Equals(SetPassword(model.Password), trimmedPass);
                }
                if (user != null && CheckPass)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный Email/пароль. Повторите заново");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (ArcheryContext db = new ArcheryContext())
                {
                    user = db.User.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    using (ArcheryContext db = new ArcheryContext())
                    {
                        model.Password = SetPassword(model.Password);
                        User newUser = new User { Email = model.Name, Password = model.Password };

                        db.User.Add(newUser);
                        db.SaveChanges();

                        user = db.User.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}