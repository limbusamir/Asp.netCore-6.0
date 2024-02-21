using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public interface IOrganizerRepository
    {
        Task<OrganizerViewModel> GetByIdAsync(int? id);
        //IQueryable<TargetGroupViewModel> GetAllAsync();
        Task<List<OrganizerViewModel>> GetAllAsync();
        Task AddAsync(OrganizerViewModel programName);
        Task UpdateAsync(OrganizerViewModel programName);
        Task DeleteAsync(int Id);
    }
}
