using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public interface IProgramNameRepository
    {
        Task<ProgramNameViewModel> GetByIdAsync(int? id);
        //IQueryable<TargetGroupViewModel> GetAllAsync();
        Task<List<ProgramNameViewModel>> GetAllAsync();
        Task AddAsync(ProgramNameViewModel programName);
        Task UpdateAsync(ProgramNameViewModel programName);
        Task DeleteAsync(int Id);
    }
}
