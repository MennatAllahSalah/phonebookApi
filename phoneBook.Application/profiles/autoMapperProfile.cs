using AutoMapper;
using phoneBook.Application.features.phoneBook.commands.creatPhone;
using phoneBook.Application.features.phoneBook.commands.deletePhone;
using phoneBook.Application.features.phoneBook.commands.updatePhone;
using phoneBook.Application.features.phoneBook.Queries.GetPhoneDetails;
using phoneBook.Application.features.phoneBook.Queries.GetPhoneList;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.profile
{
    public class autoMapperProfile :Profile
    {
        public  autoMapperProfile()
        {
            CreateMap<BookPhone, GetPhoneListViewModel>().ReverseMap();
            CreateMap<BookPhone, GetPhoneDetailsViewModel>().ReverseMap();
            CreateMap<BookPhone, creatPhoneCommand>().ReverseMap();
            CreateMap<BookPhone,updatePhoneCommand>().ReverseMap();
            CreateMap<BookPhone, deletePhoneCommand>().ReverseMap();

        }
    }
}
