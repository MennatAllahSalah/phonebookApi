using AutoMapper;
using MediatR;
using phoneBook.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQueryHandler : IRequestHandler<GetPhoneDetailsQuery,GetPhoneDetailsViewModel>
    {
       
            private readonly IPhoneBookReprosatory _phoneBookReprosatory;
            private readonly IMapper _mapper;
            public GetPhoneDetailsQueryHandler(IPhoneBookReprosatory phoneBookReprosatory, IMapper mapper)
            {
                _mapper = mapper;
                _phoneBookReprosatory = phoneBookReprosatory;
            }
            public async Task<GetPhoneDetailsViewModel> Handle(GetPhoneDetailsQuery request, CancellationToken cancellationToken)
            {
            var Phone = await _phoneBookReprosatory.GetById(request.phoneId);
                return _mapper.Map<GetPhoneDetailsViewModel>(Phone);
            }
        }
    }
