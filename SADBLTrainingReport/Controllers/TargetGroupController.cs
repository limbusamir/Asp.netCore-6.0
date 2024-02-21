using Microsoft.AspNetCore.Mvc;
using SADBLTrainingReport.Data;
using SADBLTrainingReport.Models;
using SADBLTrainingReport.Repositories;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Controllers
{
    public class TargetGroupController : Controller
    {
        private readonly ITargetGroupRepository _db;
        public TargetGroupController(ITargetGroupRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            var targetGroups = await _db.GetAllAsync();
            return View(targetGroups);
        }
        //
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TargetGroupViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            obj.created_On = DateTime.Now;
            if (ModelState.IsValid)
            {
                
                await _db.AddAsync(obj);
                TempData["SuccessMessage"] = "Target group created successfully.";

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
            var targetgrouplist = await _db.GetByIdAsync(id);
            if (targetgrouplist == null)
            {
                return NotFound();
            }
            return View(targetgrouplist);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TargetGroupViewModel obj)
        {
            obj.created_By = "susan.silwal@shangriladevelopmentbank.com";
            if (ModelState.IsValid)
            {
                await _db.UpdateAsync(obj);
                TempData["SuccessMessage"] = "Target group updated successfully.";

                return RedirectToActionPermanent("Index");
            }
            return View(obj);
        }
        ////public IActionResult Delete(int? id)
        ////{
        ////    if (id == null || id == 0)
        ////    {
        ////        return NotFound();
        ////    }
        ////    var targetgrouplist = _db.sdbl_tagregtGroup.Find(id);
        ////    if (targetgrouplist == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    _db.sdbl_tagregtGroup.Remove(targetgrouplist);
        ////    //_db.sdbl_tagregtGroup.Delete(obj);
        ////    //    _db.SaveChanges();
        ////    TempData["DeleteMessage"] = "Target group delete successfully.";
        ////    return RedirectToActionPermanent("Index");
        ////}
        //public IActionResult Delete(int id)
        //{
        //    var item = _db.sdbl_tagregtGroup.Find(id);
        //    if (item != null)
        //    {
        //        _db.sdbl_tagregtGroup.Remove(item);
        //        _db.SaveChanges();
        //    }
        //    TempData["DeleteMessage"] = "Target group deleted successfully.";
        //    return RedirectToActionPermanent("Index");
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _db.DeleteAsync(id);
            TempData["DeleteMessage"] = "Target group deleted successfully.";
            return RedirectToActionPermanent("Index");
        }
    }

}

