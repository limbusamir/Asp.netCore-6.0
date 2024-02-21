using Microsoft.AspNetCore.Mvc;
using SADBLTrainingReport.Repositories;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IOrganizerRepository _db;
        public OrganizerController(IOrganizerRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            var list = await _db.GetAllAsync();
            return View(list);
        }
        //
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrganizerViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            obj.created_On = DateTime.Now;
            if (ModelState.IsValid)
            {

                await _db.AddAsync(obj);
                TempData["SuccessMessage"] = "Organizer created successfully.";

                return RedirectToActionPermanent("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var list = await _db.GetByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrganizerViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            if (ModelState.IsValid)
            {
                await _db.UpdateAsync(obj);
                TempData["SuccessMessage"] = "Organizer updated successfully.";

                return RedirectToActionPermanent("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _db.DeleteAsync(id);
            TempData["DeleteMessage"] = "Organizer deleted successfully.";
            return RedirectToActionPermanent("Index");
        }
    }
}
