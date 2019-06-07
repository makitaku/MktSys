using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MktSys.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MainNo { get; set; }
        [Required]
        public int SubNo { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public ICollection<DailyReport> DailyReport { get; set; }
    }
}
