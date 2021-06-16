using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DbContext _Db;

        public IActionResult Index()
        {
            return View();
        }
        
        public RegisterController(DbContext Db)
        {
            _Db = Db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            _Db.Add(account);
            _Db.SaveChanges();
            ViewBag.message = "The user " + account.username + " is saved successfully";
            return View();
        }

    }
}
