using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.creatPhone
{
    public class creatPhoneCommand:IRequest<int>
    {
        public string name { get; set; }
        public string? email { get; set; }
        public string? pictureUrl { get; set; }
        public string phoneNumber { get; set; }
    }
}
