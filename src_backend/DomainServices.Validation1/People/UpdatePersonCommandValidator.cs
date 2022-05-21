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
           
        }

        private async Task<bool> UserNameMustBeUnique(UpdatePersonCommand command, string userName , CancellationToken cancellationToken)
        {
            return await mediator.Send(new CheckUserNameUniqueness (command.PersonId, userName), cancellationToken);
        }
    }

}
