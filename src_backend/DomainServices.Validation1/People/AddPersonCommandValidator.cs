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
            
        }

        private async Task<bool> userNameMustBeUnique(string userName, CancellationToken cancellationToken)
        {
            return await mediator.Send(new CheckUserNameUniqueness(null, userName), cancellationToken);
        }
    }

}
