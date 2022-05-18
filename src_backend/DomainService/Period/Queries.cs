using MediatR;

namespace DomainServices.Period
{
    internal class Queries
    {
        public record GetPeriodQuery : IRequest<Domain.Period>;
    }
}
