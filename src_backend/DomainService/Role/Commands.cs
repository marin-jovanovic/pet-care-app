using MediatR;

namespace DomainServices.Role
{
    public class Commands
    {
        public record DeleteRole(int IdRole) : IRequest;


        public class CreateRole : IRequest<int>
        {
            public int RoleId { get; set; }
            public string RoleName { get; set; }

        }

        public class UpdateRole : IRequest
        {
            public int RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
