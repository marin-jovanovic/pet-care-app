using MediatR;


namespace DomainServices.Adlisting
{
    internal class Commands
    {
       public record DeleteAdlistingCommand(int idAdlisting):IRequest;

        public class UpdateAdlistingCommand : IRequest
        {
            public string Description { get; set; }
            public double Price { get; set; }
            public int IdAdListing { get; set; }
            public int IdDescriptable { get; set; }
            public string UserName { get; set; }
            public int? IdLocation { get; set; }
            public int? IdPeriod { get; set; }
        }
        public class AddAdlisting : IRequest<int>
        {
            public string Description { get; set; }
            public double Price { get; set; }
            public int IdAdListing { get; set; }
            public int IdDescriptable { get; set; }
            public string UserName { get; set; }
            public int? IdLocation { get; set; }
            public int? IdPeriod { get; set; }
        }
    }
}
