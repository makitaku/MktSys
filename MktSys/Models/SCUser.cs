using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MktSys.Models
{
    public class SCUser
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birth { get; set; }
    }
}
