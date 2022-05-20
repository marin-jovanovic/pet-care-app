
using MediatR;

namespace DomainServices.People;
    public class Commands
    {
        public record DeletePersonCommand(string username):IRequest;
        public class UpdatePersonCommand : IRequest
        {
            public string userName { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string mobileNumber { get; set; }

            public int idPerson { get; set; }
        }
        public class AddPersonCommand : IRequest<int>
        {
            public string userName { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string mobileNumber { get; set; }

            public int idPerson { get; set; }
    }
    }

