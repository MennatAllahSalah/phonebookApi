using MediatR;
using phoneBook.Application.interfaces;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.deletePhone
{
 public class deletePhoneCommandHandler
    {
        private readonly IPhoneBookReprosatory _phoneBookReprosatory;
        
        public deletePhoneCommandHandler(IPhoneBookReprosatory phoneBookReprosatory)
        {
           
            _phoneBookReprosatory = phoneBookReprosatory;
        }
        public async Task<Unit> Handle(deletePhoneCommand request, CancellationToken cancellationToken)
        {
            BookPhone Phone = await _phoneBookReprosatory.GetById(request.id);

            await _phoneBookReprosatory.delete(Phone);
            return Unit.Value;

        }
    }
}
