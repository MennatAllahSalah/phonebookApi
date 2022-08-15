using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.updatePhone
{
  public class updatePhoneCommand :IRequest
    {
        public string name { get; set; }
        public int Id { get; set; }
        
        public string? email { get; set; }
        public string? pictureUrl { get; set; }
        public string phoneNumber { get; set; }
    }
}
