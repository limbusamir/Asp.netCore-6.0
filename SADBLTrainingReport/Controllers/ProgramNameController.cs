using Microsoft.AspNetCore.Mvc;
using SADBLTrainingReport.Repositories;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Controllers
{
    public class ProgramNameController : Controller
    {
        private readonly IProgramNameRepository _db;
        public ProgramNameController(IProgramNameRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            var programName = await _db.GetAllAsync();
            return View(programName);
        }
        //
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProgramNameViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            obj.created_On = DateTime.Now;
            if (ModelState.IsValid)
            {

                await _db.AddAsync(obj);
                TempData["SuccessMessage"] = "ProgramName created successfully.";

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
            var programNamelist = await _db.GetByIdAsync(id);
            if (programNamelist == null)
            {
                return NotFound();
            }
            return View(programNamelist);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProgramNameViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            if (ModelState.IsValid)
            {
                await _db.UpdateAsync(obj);
                TempData["SuccessMessage"] = "ProgramName updated successfully.";

                return RedirectToActionPermanent("Index");
            }
            return View(obj);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _db.DeleteAsync(id);
            TempData["DeleteMessage"] = "ProgramName deleted successfully.";
            return RedirectToActionPermanent("Index");
        }
    }
}
