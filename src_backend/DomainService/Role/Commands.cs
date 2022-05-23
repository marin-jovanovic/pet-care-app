using MediatR;

namespace DomainServices.Role
{
    public class Commands
    {
        public record DeleteRole(int IdRole) : IRequest;


        public record CreateRoleCommand(string RoleName) : IRequest<int>;

        public class UpdateRole : IRequest
        {
            public int RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
