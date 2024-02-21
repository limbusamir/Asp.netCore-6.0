using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SADBLTrainingReport.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Organizer Name")]
        public string organizerName { get; set; }

        [DisplayName("Created By")]
        public string? created_By { get; set; }
        public DateTime? created_On { get; set; }
    }
}
