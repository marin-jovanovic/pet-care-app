using FluentValidation;
using MediatR;
using static DomainServices.People.Commands;

namespace DomainServices.Validation.People
{
    public  class UpdatePersonCommandValidator: AbstractValidator<UpdatePersonCommand>
    {
        private readonly IMediator mediator;
        public UpdatePersonCommandValidator(IMediator mediator)
        {

            this.mediator = mediator;
            RuleFor(p=>p.email).NotEmpty();
            RuleFor(p => p.userName).NotEmpty().MaximumLength(20)
            .DependentRules(() => RuleFor(p => p.userName)
                                .MustAsync(UserNameMustBeUnique)
                                .WithMessage("Personal identification number must be unique")
                        );
        }

        private async Task<bool> UserNameMustBeUnique(UpdatePersonCommand command, string userName , CancellationToken cancellationToken)
        {
            return await mediator.Send(new CheckUserNameUniqueness (command.idPerson, userName), cancellationToken);
        }
    }

}
