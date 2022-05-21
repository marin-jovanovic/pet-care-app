using MediatR;

namespace DomainServices.Pet
{
    public class Commands
    {
        public record DeletePet(int idPet) : IRequest;


        public class CreatePet : IRequest<int>
        {
            public int PetId { get; set; }
            public string PetName { get; set; }
            public bool? Sex { get; set; }
            public string Size { get; set; }
            public string PetType { get; set; }
            public string Breed { get; set; }

        }

        public class UpdatePet : IRequest
        {
            public int PetId { get; set; }
            public string PetName { get; set; }
            public bool? Sex { get; set; }
            public string Size { get; set; }
            public string PetType { get; set; }
            public string Breed { get; set; }
        }
    }
}
