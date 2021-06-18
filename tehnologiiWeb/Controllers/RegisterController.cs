using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.DataAccess;
using tehnologiiWeb.Domain;
using tehnologiiWeb.Web.Models;

namespace tehnologiiWeb.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DbContext _Db;

        public IActionResult Index()
        {
            return View();
        }
        
        public RegisterController(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegisterViewModel model)
        {
            var newAccount = new Account();

            

            if (ModelState.IsValid)
            {
                newAccount.Username = model.Username;
                newAccount.FullName = model.FullName;
                newAccount.Email = model.Email;
                newAccount.Password = model.Password;

                _Db.Add(newAccount);
                _Db.SaveChanges();
                ViewBag.message = "The user " + newAccount.Username + " is saved successfully";
                    //await newAccount. SignInAsync(user, isPersistent: false);

                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.message = "Invalid credentials";
            }
            
            return View();
        }

    }
}
