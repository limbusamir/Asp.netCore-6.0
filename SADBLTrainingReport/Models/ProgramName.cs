﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SADBLTrainingReport.Models
{
    public class ProgramName
    {
            [Key]
            public int Id { get; set; }
            [Required]
            [DisplayName("Program Name")]
            public string programName { get; set; }

            [DisplayName("Created By")]
            public string? created_By { get; set; }
            public DateTime? created_On { get; set; }
        
    }
}