using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.Queries.GetPhoneList
{
    public class GetPhoneListQuery : IRequest<List<GetPhoneListViewModel>>
    {
    }
}
