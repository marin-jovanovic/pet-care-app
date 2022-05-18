using FluentValidation;
using MediatR;
using static DomainServices.People.Commands;

namespace DomainServices.Validation.People
{
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {


        private readonly IMediator mediator;

        public AddPersonCommandValidator(IMediator mediator)
        {
            this.mediator = mediator;
            RuleFor(p => p.email).NotEmpty().MaximumLength(25);
            RuleFor(p => p.mobileNumber).NotEmpty().Matches("[0-9]").WithMessage("Broj mora bit unesen s brojevim").MaximumLength(25);
            RuleFor(p => p.password).NotEmpty().WithMessage("Password is required.");
            RuleFor(p => p.userName).NotEmpty().MaximumLength(11)
              .DependentRules(() => RuleFor(p => p.userName)
                                      .MustAsync(userNameMustBeUnique)
                                      .WithMessage("User name is required.")
                              );
        }

        private async Task<bool> userNameMustBeUnique(string userName, CancellationToken cancellationToken)
        {
            return await mediator.Send(new CheckUserNameUniqueness(null, userName), cancellationToken);
        }
    }

}
