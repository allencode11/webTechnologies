using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.Domain;
using System.Threading.Tasks;
using tehnologiiWeb.Web.Models;
using tehnologiiWeb.DataAccess;

namespace tehnologiiWeb.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public LoginController(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnURL = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _Db.accounts.FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (result == null)
                {
                 
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

    }
}  


