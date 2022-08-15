using phoneBook.Application.features.phoneBook.Queries.GetPhoneList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.Queries.GetPhoneDetails
{
   public class GetPhoneDetailsViewModel
    {
        public string name { get; set; }
        public int Id { get; set; }

        public string phoneNumber { get; set; }
        //   public phoneDto phone { get; set; }
    }
}
