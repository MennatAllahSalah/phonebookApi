using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.features.phoneBook.commands.creatPhone
{
   public class CreatPhoneCommandValidator : AbstractValidator<creatPhoneCommand>
    {
       public CreatPhoneCommandValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(p => p.phoneNumber)
               .NotEmpty()
               .NotNull()
               .MaximumLength(11);
        }
    }
}
