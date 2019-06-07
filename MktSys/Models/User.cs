using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MktSys.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int No { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birth { get; set; }

        public ICollection<DailyReport> DailyReport { get; set; }
    }
}
