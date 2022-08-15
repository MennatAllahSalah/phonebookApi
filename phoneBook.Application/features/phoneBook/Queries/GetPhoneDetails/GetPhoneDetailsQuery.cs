using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.Queries.GetPhoneDetails
{
   public class GetPhoneDetailsQuery :IRequest<GetPhoneDetailsViewModel>
    {
        public int phoneId { get; set; }
    }
}
