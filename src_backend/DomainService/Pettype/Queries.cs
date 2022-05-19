using MediatR;
using Domain;
namespace DomainServices.Pettype
{
    public class Queries
    {
        public record GetPettypeQuery(int IdPettype) : IRequest<Domain.Pettype>;
        public record GetPettypesQuery : IRequest<IList<Domain.Pettype>>;
    }
}
