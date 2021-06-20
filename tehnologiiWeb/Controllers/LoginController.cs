using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.Domain;
using System.Threading.Tasks;
using tehnologiiWeb.Web.Models;
using tehnologiiWeb.DataAccess;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

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
        public IActionResult Index(string ReturnUrl = "/")
        {
            LoginViewModel objLoginModel = new LoginViewModel();
            objLoginModel.ReturnURL = ReturnUrl;
            return View(objLoginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _Db.accounts.FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (result == null)
                {
                    ViewBag.message = "Invalid credentials!";
                }
                else
                {
                    ViewBag.message = result.Role;

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, Convert.ToString(result.Id)),
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Role, result.Role)
                    };

                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    });
                    return LocalRedirect(model.ReturnURL);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }

}


