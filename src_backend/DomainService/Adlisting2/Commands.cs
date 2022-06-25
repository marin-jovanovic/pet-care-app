using MediatR;


namespace DomainServices.Adlisting2
{
    public class Commands
    {
        public record DeleteAdlistingCommand2(int idAdlisting) : IRequest;

        public class UpdateAdlistingCommand2 : IRequest
        {
            public int ListingId { get; set; }
            public string Description { get; set; }
            public int UserId { get; set; }

        }
        public class AddAdlistingCommand2 : IRequest<int>
        {
            public int ListingId { get; set; }
            public string Description { get; set; }
            public int UserId { get; set; }
        }
    }
}
