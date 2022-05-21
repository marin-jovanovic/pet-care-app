using MediatR;

namespace DomainServices.PersonRole
{
    public class Commands
    {
        public record DeletePersonRoleCommand(int personId) : IRequest;
        public class UpdatePersonRoleCommand : IRequest
        {
            public int PersonId { get; set; }
            public int AdlistingId { get; set; }
            public DateTime AssigmentDate { get; set; }
            public int RoleId { get; set; }
        }
        public class AddPersonRoleCommand : IRequest<int>
        {
            public int PersonId { get; set; }
            public int AdlistingId { get; set; }
            public DateTime AssigmentDate { get; set; }
            public int RoleId { get; set; }
        }
    }
}
