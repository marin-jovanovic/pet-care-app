using MediatR;

namespace DomainServices.Pettype
{
    internal class Queries
    {
        public record GetPettypeQuery : IRequest<Domain.Pettype>;
    }
}
