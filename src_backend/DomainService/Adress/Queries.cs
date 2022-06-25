using MediatR;
using Sieve.Models;

namespace DomainServices.Adress
{
    public class Queries
    {

        public record GetAdressQuery : IRequest<IList<Domain.Adress>>
        {

            public SieveModel Criteria { get; set; }
        }

        public record GetOneAdressQuery(int IdAdress):IRequest<Domain.Adress>;
    }
}
