using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using phoneBook.Application.interfaces;

namespace phoneBook.Application.features.phoneBook.Queries.GetPhoneList
{
    public class GetPhonesListQueryHandler : IRequestHandler<GetPhoneListQuery, List<GetPhoneListViewModel>>
    {
        private readonly IPhoneBookReprosatory _phoneBookReprosatory;
        private readonly IMapper _mapper;
        public GetPhonesListQueryHandler(IPhoneBookReprosatory phoneBookReprosatory, IMapper mapper)
        {
            _mapper = mapper;
            _phoneBookReprosatory = phoneBookReprosatory;
        }
        public async Task<List<GetPhoneListViewModel>> Handle(GetPhoneListQuery request,CancellationToken cancellationToken)
            {
            var allPhones = await _phoneBookReprosatory.GetAl();
            return _mapper.Map<List<GetPhoneListViewModel>>(allPhones);
            }
    }
}
