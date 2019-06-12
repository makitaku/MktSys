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
        //        [MaxLength(3)]
        [Range(0,999)]
        public int No { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        //        [Range(4,12)]
        [MaxLength(12)]
        [MinLength(4)]
        public string Password { get; set; }
        //        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        public ICollection<DailyReport> DailyReport { get; set; }
    }
}
