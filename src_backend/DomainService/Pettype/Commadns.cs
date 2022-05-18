using MediatR;

namespace DomainServices.Pettype
{
    public class Commadns
    {
        public record DeletePettype(int IdPetType):IRequest;
        public record CreatePettype(int IdPetType,string TypePetName) :IRequest;

        public class UpdatePettype : IRequest
        {
            public int IdPetType { get; set; }
            public string? TypePetName { get; set; }
        }

         
    }
}
