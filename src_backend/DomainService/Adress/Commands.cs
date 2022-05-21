using MediatR;
using Domain;

namespace DomainServices.Adress

{
    public class Commands
    {
        public record DeleteAdressCommand(int adressId) : IRequest;
        public class AddAdressCommand : IRequest<int>
        {
            public int AdressId { get; set; }
            public string Adress1 { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
            public bool? IsHouse { get; set; }
            public int? Floor { get; set; }
        }
        public class UpdateAdressCommand : IRequest
        {
            public int AdressId { get; set; }
            public string Adress1 { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
            public bool? IsHouse { get; set; }
            public int? Floor { get; set; }

        }
    }
}
