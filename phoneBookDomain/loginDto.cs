using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBookDomain
{
   public class loginDto
    {
        [Required]
        public string UserNAme { get; set; }

        [Required]
        public string PAssword { get; set; }
    }
}
