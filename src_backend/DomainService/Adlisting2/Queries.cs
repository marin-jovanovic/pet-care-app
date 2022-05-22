using MediatR;
using Sieve.Models;

namespace DomainServices.Adlisting2
{
    public class Queries
    {
        public class GetAdlistingQuery2 : IRequest<IList<Domain.Adlisting2>>
        {
            public SieveModel Criteria { get; set; }
        }

        public record GetAdlistQuery2(int IdAdListing, CancellationToken CancellationToken) : IRequest<Domain.Adlisting2>;
    }
}

