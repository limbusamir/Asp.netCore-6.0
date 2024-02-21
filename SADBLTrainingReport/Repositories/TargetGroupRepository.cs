using Microsoft.EntityFrameworkCore;
using SADBLTrainingReport.Data;
using SADBLTrainingReport.Models;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public class TargetGroupRepository : ITargetGroupRepository
    {
        private readonly ApplicationDBContext _db;
        //Dependency Injection
        public TargetGroupRepository(ApplicationDBContext db)
        {
            _db = db;

        }
        public async Task<TargetGroupViewModel> GetByIdAsync(int? id)
        {
            var targetGroup = await _db.sdbl_tagregtGroup.FindAsync(id);
            var targetGroupViewModel = new TargetGroupViewModel
            {
                Id = targetGroup.Id,
                targetName = targetGroup.targetName
            };
            return targetGroupViewModel;
        }

        public async Task<List<TargetGroupViewModel>> GetAllAsync()
        {
            var targetGroup = await _db.sdbl_tagregtGroup.ToListAsync();
            List<TargetGroupViewModel> targetGroupViewModels = new List<TargetGroupViewModel>();
            foreach (var targetG in targetGroup)
            {
                var targetGroupViewModel = new TargetGroupViewModel
                {
                    Id = targetG.Id,
                    targetName = targetG.targetName,
                    created_By=targetG.created_By,
                    created_On =targetG.created_On
                };

                targetGroupViewModels.Add(targetGroupViewModel);
            }

            return targetGroupViewModels;

        }
        //public IQueryable<TargetGroupViewModel> GetAllAsync()
        //{
        //    var targetgroup = _db.sdbl_tagregtGroup
        //    .Select(e => new TargetGroupViewModel
        //    {
        //        Id = e.Id,
        //        targetName = e.targetName,
        //        created_By = e.created_By
        //    });

        //    return targetgroup;
        //}
        public async Task AddAsync(TargetGroupViewModel targetGroup)
        {
            var newTargetgroup = new TargetGroup()
            {
                targetName = targetGroup.targetName,
                created_By=targetGroup.created_By,
                created_On=targetGroup.created_On
                
            };
            await _db.sdbl_tagregtGroup.AddAsync(newTargetgroup);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TargetGroupViewModel targetgroupUpdated)
        {
            var targetGroup = await _db.sdbl_tagregtGroup.FindAsync(targetgroupUpdated.Id);
            targetGroup.targetName = targetgroupUpdated.targetName;
            targetGroup.created_By = targetgroupUpdated.created_By;

            _db.sdbl_tagregtGroup.Update(targetGroup);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            TargetGroup targetGroup = await _db.sdbl_tagregtGroup.FindAsync(Id);
            _db.sdbl_tagregtGroup.Remove(targetGroup);
            await _db.SaveChangesAsync();
        }

    }
}
