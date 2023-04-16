using FluentValidation;
using Homework2.Data.Model;

namespace Homework2.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id is invalid.");


            RuleFor(x => x.UserName)
                .MinimumLength(10)
                .WithMessage("The 'Name' should have at least 10 characters.")
                .MaximumLength(40)
                .WithMessage("The 'Name' should have not more than 40 characters.");


            RuleFor(x => x.Email)
                .EmailAddress();


        }
    }
}
