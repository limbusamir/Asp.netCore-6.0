using Microsoft.EntityFrameworkCore;
using SADBLTrainingReport.Data;
using SADBLTrainingReport.Models;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public class OrganizerRepository:IOrganizerRepository
    {
        private readonly ApplicationDBContext _db;
        //Dependency Injection
        public OrganizerRepository(ApplicationDBContext db)
        {
            _db = db;

        }
        public async Task<OrganizerViewModel> GetByIdAsync(int? id)
        {
            var list = await _db.sdbl_organizer.FindAsync(id);
            var ViewModel = new OrganizerViewModel
            {
                Id = list.Id,
                organizerName = list.organizerName
            };
            return ViewModel;
        }

        public async Task<List<OrganizerViewModel>> GetAllAsync()
        {
            var list = await _db.sdbl_organizer.ToListAsync();
            List<OrganizerViewModel> ViewModels = new List<OrganizerViewModel>();
            foreach (var data in list)
            {
                var ViewModel = new OrganizerViewModel
                {
                    Id = data.Id,
                    organizerName = data.organizerName,
                    created_By = data.created_By,
                    created_On = data.created_On
                };

                ViewModels.Add(ViewModel);
            }

            return ViewModels;

        }

        public async Task AddAsync(OrganizerViewModel model)
        {
            var newModel = new Organizer()
            {
                organizerName = model.organizerName,
                created_By = model.created_By,
                created_On = model.created_On

            };
            await _db.sdbl_organizer.AddAsync(newModel);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrganizerViewModel modelupdated)
        {
            var list = await _db.sdbl_organizer.FindAsync(modelupdated.Id);
            list.organizerName = modelupdated.organizerName;
            list.created_By = modelupdated.created_By;

            _db.sdbl_organizer.Update(list);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Organizer list = await _db.sdbl_organizer.FindAsync(Id);
            _db.sdbl_organizer.Remove(list);
            await _db.SaveChangesAsync();
        }
    }
}
