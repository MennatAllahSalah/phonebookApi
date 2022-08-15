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

namespace phoneBook.Application.features.phoneBook.commands.creatPhone
{
    public class CreatPhoneCommandHandler :  IRequestHandler<creatPhoneCommand, int>
    {
        private readonly IPhoneBookReprosatory _phoneBookReprosatory;
        private readonly IMapper _mapper;
        public CreatPhoneCommandHandler(IPhoneBookReprosatory phoneBookReprosatory, IMapper mapper)
        {
            _mapper = mapper;
            _phoneBookReprosatory = phoneBookReprosatory;
        }
        public async Task<int> Handle(creatPhoneCommand request, CancellationToken cancellationToken)
        {
            BookPhone Phone = _mapper.Map<BookPhone>(request);
            CreatPhoneCommandValidator validator = new CreatPhoneCommandValidator();
            var result = await validator.ValidateAsync(request);
            if(result.Errors.Any())
            {
                throw new Exception("not valid");
            }
            Phone = await _phoneBookReprosatory.Add(Phone);
            return Phone.Id;
           
        }
    }
}
