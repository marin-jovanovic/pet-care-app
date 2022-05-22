using MediatR;
using Sieve.Models;

namespace DomainServices.PersonRole
{
    public class Queries
    {
        public class GetPersonRolesQuery : IRequest<IList<Domain.PersonRole>>
        {
    
            public SieveModel Criteria { get; set; }
        }


        public record GetPersonRoleQuery(int idPersonRole, bool IncludeProjects) : IRequest<Domain.PersonRole>;
    }
}
