using AutoMapper;
using MediatR;
using phoneBook.Application.interfaces;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.updatePhone
{
    public class updatePhoneCommandHandler :IRequestHandler<updatePhoneCommand>

    {
        private readonly IRerprosatory<BookPhone> _phoneBookReprosatory;
        private readonly IMapper _mapper;
        public updatePhoneCommandHandler(IPhoneBookReprosatory phoneBookReprosatory, IMapper mapper)
        {
            _mapper = mapper;
            _phoneBookReprosatory = phoneBookReprosatory;
        }
        public async Task<Unit> Handle(updatePhoneCommand request, CancellationToken cancellationToken)
        {
            BookPhone Phone = _mapper.Map<BookPhone>(request);
           
             await _phoneBookReprosatory.update(Phone);
            return Unit.Value;

        }
    }
}
