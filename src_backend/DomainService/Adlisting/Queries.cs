
using MediatR;
using Domain;
using Sieve.Models;

namespace DomainServices.Adlisting
{
    public class Queries
    {
        public class GetAdlistingQuery : IRequest<IList<Domain.Adlisting>>
        {
            public SieveModel Criteria { get; set; }    
        }
       
        public record GetAdlistQuery(int IdAdListing, CancellationToken CancellationToken):IRequest<Domain.Adlisting>;
    }
}
