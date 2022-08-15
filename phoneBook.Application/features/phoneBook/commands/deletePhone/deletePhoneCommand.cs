using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.deletePhone
{
    public class deletePhoneCommand : IRequest
    {
        public int id { get; set; }
    }
}
