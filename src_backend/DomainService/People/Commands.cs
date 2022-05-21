
using MediatR;

namespace DomainServices.People;
    public class Commands
    {
        public record DeletePersonCommand(int personId):IRequest;
        public class UpdatePersonCommand : IRequest
        {
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string Oib { get; set; }
        public string PersonEmail { get; set; }
        public string PersonMobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
        public class AddPersonCommand : IRequest<int>
        {
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string Oib { get; set; }
        public string PersonEmail { get; set; }
        public string PersonMobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
    }

