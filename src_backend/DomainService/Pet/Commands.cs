using MediatR;

namespace DomainServices.Pet
{
    public class Commands
    {
        public record DeletePet(int IdPet) : IRequest;
        public class CreatePettype : IRequest<int>
        {
            public int IdPet { get; set; }
            public string? Name { get; set; }
            public int age { get; set; }

            public string? Description { get; set; }

         }

        public class UpdatePettype : IRequest
        {
            public int IdPetType { get; set; }
            public string? TypePetName { get; set; }
        }
    }
}
