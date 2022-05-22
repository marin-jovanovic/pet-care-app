namespace PetCareAppMVC.Features.Pet { 
    public class PetViewModel
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public bool? Sex { get; set; }
        public string Size { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
    }
}
