using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MktSys.Models
{
    public class WorkType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int No { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<DailyReport> DailyReport { get; set; }

    }
}
