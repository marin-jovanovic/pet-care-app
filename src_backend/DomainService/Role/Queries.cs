using MediatR;

using Sieve.Models;

namespace DomainServices.Role
{
    public class Queries
    {
        public class GetRolesQuery : IRequest<IList<Domain.Role>>
        {
            public SieveModel Criteria { get; set; }
        }

        public record GetRoleQuery(int RoleId) : IRequest<Domain.Role>;
    }
}
