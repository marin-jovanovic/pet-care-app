using MediatR;
using Sieve.Models;

namespace DomainServices.Person2
{
    public class Queries
    {
        public class GetPeopleQuery2 : IRequest<IList<Domain.Person2>>
        {
            //sieve adds sorting, filtering, and pagination functionality out of the box. Most common use case would be for serving ASP.NET Core GET queries
            public SieveModel Criteria { get; set; }
        }


        public record GetPersonQuery2(int idPerson, bool IncludeProjects) : IRequest<Domain.Person2>;
    }
}
