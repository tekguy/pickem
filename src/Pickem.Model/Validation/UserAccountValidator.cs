using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Pickem.Model.Validation
{
    public class UserAccountValidator : AbstractValidator<UserAccount>
    {
        public override ValidationResult Validate(UserAccount instance)
        {
            RuleFor(m => m.Password).NotEmpty().Length(0, 20);
            return base.Validate(instance);
        }
    }
}
