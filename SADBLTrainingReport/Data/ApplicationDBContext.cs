using Microsoft.EntityFrameworkCore;
using SADBLTrainingReport.Models;

namespace SADBLTrainingReport.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
                
        }
        public DbSet<TargetGroup> sdbl_tagregtGroup { get; set; }
        public DbSet<ProgramName> sdbl_programName { get; set; }
        public DbSet<Organizer> sdbl_organizer { get; set; }
    }
}
