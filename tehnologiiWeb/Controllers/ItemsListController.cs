using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tehnologiiWeb.Domain;
using tehnologiiWeb.DataAccess;
using System.Threading.Tasks;

namespace tehnologiiWeb.Web.Controllers
{
    public class ItemsListController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public ItemsListController(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        public IActionResult Index()
        {

            ViewBag.items = _Db.items.ToList();

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Item model)
        {

            if (ModelState.IsValid)
            {
                await _Db.items.AddAsync(model);
                await _Db.SaveChangesAsync();
                ViewBag.message = "The product: " + model.Name + " is saved successfully";
                return RedirectToPage("/Index");
            }
            else
            {
                ViewBag.message = "Invalid data";
                return View();
            }

        }
    }
}
