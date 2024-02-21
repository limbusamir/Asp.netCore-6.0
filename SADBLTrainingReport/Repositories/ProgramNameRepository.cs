using Microsoft.EntityFrameworkCore;
using SADBLTrainingReport.Data;
using SADBLTrainingReport.Models;
using SADBLTrainingReport.ViewModels;

namespace SADBLTrainingReport.Repositories
{
    public class ProgramNameRepository: IProgramNameRepository
    {
        private readonly ApplicationDBContext _db;
        //Dependency Injection
        public ProgramNameRepository(ApplicationDBContext db)
        {
            _db = db;

        }
        public async Task<ProgramNameViewModel> GetByIdAsync(int? id)
        {
            var programN = await _db.sdbl_programName.FindAsync(id);
            var programNameViewModel = new ProgramNameViewModel
            {
                Id = programN.Id,
                programName = programN.programName
            };
            return programNameViewModel;
        }

        public async Task<List<ProgramNameViewModel>> GetAllAsync()
        {
            var programN = await _db.sdbl_programName.ToListAsync();
            List<ProgramNameViewModel> programNameViewModels = new List<ProgramNameViewModel>();
            foreach (var programName in programN)
            {
                var programNameViewModel = new ProgramNameViewModel
                {
                    Id = programName.Id,
                    programName = programName.programName,
                    created_By = programName.created_By,
                    created_On = programName.created_On
                };

                programNameViewModels.Add(programNameViewModel);
            }

            return programNameViewModels;

        }
        
        public async Task AddAsync(ProgramNameViewModel programName)
        {
            var newProgramName = new ProgramName()
            {
                programName = programName.programName,
                created_By = programName.created_By,
                created_On = programName.created_On

            };
            await _db.sdbl_programName.AddAsync(newProgramName);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProgramNameViewModel programNameupdated)
        {
            var programName = await _db.sdbl_programName.FindAsync(programNameupdated.Id);
            programName.programName = programNameupdated.programName;
            programName.created_By = programNameupdated.created_By;

            _db.sdbl_programName.Update(programName);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            ProgramName programName = await _db.sdbl_programName.FindAsync(Id);
            _db.sdbl_programName.Remove(programName);
            await _db.SaveChangesAsync();
        }
    }
}
