

using MediatR;
namespace DomainServices.Validation;

    public record CheckUserNameUniqueness(int? PersonId, string userName) : IRequest<bool>
    {
    }
