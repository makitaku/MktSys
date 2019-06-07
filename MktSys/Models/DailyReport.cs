using System;
using System.ComponentModel.DataAnnotations;

namespace MktSys.Models
{
    public class DailyReport
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }

        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual WorkType WorkType { get; set; }


    }
}
