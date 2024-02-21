﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SADBLTrainingReport.Models
{
    public class TargetGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Target Name")]
        public string targetName { get; set; }
        
        [DisplayName("Created By")]
        public string? created_By { get; set; }
        public DateTime? created_On { get; set; }
    }
}
