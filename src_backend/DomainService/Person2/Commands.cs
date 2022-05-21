using MediatR;

namespace DomainServices.Person2
{
    public class Commands
    {
        public record DeletePersonCommand2(int id) : IRequest;
        public class UpdatePersonCommand2 : IRequest
        {
            public int PersonId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string SessionId { get; set; }
        }
        public class AddPersonCommand2 : IRequest<int>
        {
            public int PersonId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string SessionId { get; set; }
        }
    }
}
