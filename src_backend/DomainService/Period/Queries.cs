using MediatR;

namespace DomainServices.Period
{
    public class Queries
    {
        public record GetPeriodQuery(int IdPeriod) : IRequest<Domain.Period>;
        public record GetPeriodsQuery : IRequest<IList<Domain.Period>>;
    }
}
