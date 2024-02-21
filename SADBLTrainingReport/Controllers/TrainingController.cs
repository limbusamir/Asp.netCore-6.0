using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SADBLTrainingReport.Data;
using SADBLTrainingReport.Models;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Controllers
{
    public class TrainingController : Controller
    {
        protected readonly ApplicationDBContext _db;
        public TrainingController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var targetGroup=_db.sdbl_tagregtGroup.ToList();
            //ViewBag.TargetGroup = new SelectList(targetGroup, "Id", "targetName");
            return View(new TrainingConduct());
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            var viewModel = new TrainConductedViewModel
            {
                TrainerRows = GetTrainerRows(),
                StaffRows = GetStaffRows()
            };

            return View(viewModel);


        }
        private List<TrainerRowModel> GetTrainerRows()
        {
            var model = new List<TrainerRowModel>
            {
                new TrainerRowModel { SNNo = "1", trainerName = "" }
                // Add more initial rows if needed
            };
            return model;
        }

        private List<StaffRowModel> GetStaffRows()
        {
            var model = new List<StaffRowModel>
            {
                new StaffRowModel { SNNo = "1", staffName = "" }
                // Add more initial rows if needed
            };
            return model;
        }
    }
}
