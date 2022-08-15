using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBookDomain
{
public class Phones
    {
        public int id { get; set; }
        [ForeignKey("BookPhone")]
        public int bookid { get; set; }
        public string phone { get; set; }
        public virtual BookPhone BookPhone { get; set; }
    }
}
