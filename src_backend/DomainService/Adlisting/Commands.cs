using MediatR;


namespace DomainServices.Adlisting
{
    public class Commands
    {
       public record DeleteAdlistingCommand(int idAdlisting):IRequest;

        public class UpdateAdlistingCommand : IRequest
        {
            public int AdlistingId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? IdAdress { get; set; }
            public string AdlistingDescription { get; set; }
            public bool? IsActive { get; set; }
            public double? Price { get; set; }
            public string Title { get; set; }
            public int PetId { get; set; }
            public bool? IsActiv { get; set; }
        }
        public class AddAdlisting : IRequest<int>
        {
            public int AdlistingId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? IdAdress { get; set; }
            public string AdlistingDescription { get; set; }
            public bool? IsActive { get; set; }
            public double? Price { get; set; }
            public string Title { get; set; }
            public int PetId { get; set; }
            public bool? IsActiv { get; set; }
        }
    }
}
