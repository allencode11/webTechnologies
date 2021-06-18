using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tehnologiiWeb.DataAccess;
using System.Threading.Tasks;
using tehnologiiWeb.Web.Models;
using tehnologiiWeb.Domain;

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
        public async Task<IActionResult> Create(ItemsViewModel model)
        { 
            if (model.Id == null)
            {
                var itemModel = new Item();

                if (ModelState.IsValid)
                {
                    itemModel.Name = model.Name;
                    itemModel.Owner = model.Owner;
                    itemModel.Price = model.Price;
                    itemModel.StringUrl = model.StringUrl;
                    itemModel.Email = model.Email;
                    itemModel.Category = model.Category;
             
                    await _Db.items.AddAsync(itemModel);
                    await _Db.SaveChangesAsync();
                    return RedirectToAction("Index"); 
                }

                return ViewBag.message = "Incorect data";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var itemFromDb = await _Db.items.FindAsync(model.Id);
                    itemFromDb.Name = model.Name;
                    itemFromDb.Owner = model.Owner;
                    itemFromDb.Email = model.Email;

                    await _Db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    return ViewBag.message = "Incorect data";
                }
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ItemsViewModel model)
        {
            var item = await _Db.items.FindAsync(model.Id);
            if (item == null)
            {
                return NotFound();

            }
            _Db.items.Remove(item);
            await _Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
