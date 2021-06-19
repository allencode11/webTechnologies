using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tehnologiiWeb.DataAccess;
using System.Threading.Tasks;
using tehnologiiWeb.Web.Models;
using tehnologiiWeb.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Create(int? id)
        {
            if(id is null)
            {
                return View(new ItemsViewModel());
            }

            var itemFromDb = await _Db.items.FirstOrDefaultAsync(item => item.Id == id.Value);
            if (itemFromDb is null)
            {
                ViewBag.message = "Invalid data";
                return View(new ItemsViewModel());
            }

            var r = new ItemsViewModel { Id = itemFromDb.Id,
                                         Category = itemFromDb.Category,
                                         Email = itemFromDb.Email,
                                         Owner = itemFromDb.Owner, 
                                         Name = itemFromDb.Name, 
                                         Price = itemFromDb.Price, 
                                         StringUrl = itemFromDb.StringUrl };


            return View(r);
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
