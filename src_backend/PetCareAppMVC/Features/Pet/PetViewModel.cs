namespace PetCareAppMVC.Features.Pet
{
    public class PetViewModel
    {
        public int PetId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IdDescriptable { get; set; }
        public string UserName { get; set; }
        public int IdPetType { get; set; }

        public string TypePetName { get; set; }

    }
}
