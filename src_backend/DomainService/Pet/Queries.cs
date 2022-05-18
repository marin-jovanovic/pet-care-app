using MediatR;

using Sieve.Models;

namespace DomainServices.Pet
{
    public class Queries
    {
        public class GetPetsQuery : IRequest<IList<Domain.Pet>>
        {
            public SieveModel Criteria { get; set; }
        }

        public record GetPetQuery(int petId) : IRequest<Domain.Pet>;
    }
}
