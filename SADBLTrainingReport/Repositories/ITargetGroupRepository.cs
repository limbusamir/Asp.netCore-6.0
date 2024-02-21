using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public interface ITargetGroupRepository
    {
        Task<TargetGroupViewModel> GetByIdAsync(int? id);
        //IQueryable<TargetGroupViewModel> GetAllAsync();
        Task<List<TargetGroupViewModel>> GetAllAsync();
        Task AddAsync(TargetGroupViewModel targetGroup);
        Task UpdateAsync(TargetGroupViewModel targetGroup);
        Task DeleteAsync(int Id);
    }
}
