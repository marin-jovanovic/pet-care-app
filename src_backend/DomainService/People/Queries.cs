
using Domain.People;
using MediatR;
using Sieve.Models;



namespace DomainServices.People
{
    public class Queries
    {
        public class GetPeopleQuery : IRequest<IList<Person>> {
            //sieve adds sorting, filtering, and pagination functionality out of the box. Most common use case would be for serving ASP.NET Core GET queries
            public SieveModel Criteria { get; set; }
        }
   

    public record GetPersonQuery(int idPerson, bool IncludeProjects) : IRequest<Person>;
    }
}
