using SADBLTrainingReport.Models;

namespace SADBLTrainingReport.ViewModels
{
    public class TrainConductedViewModel
    {
        public List<TrainerRowModel> TrainerRows { get; set; }
        public List<StaffRowModel> StaffRows { get; set; }
    }
}
