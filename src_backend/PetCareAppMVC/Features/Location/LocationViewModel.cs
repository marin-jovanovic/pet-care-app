namespace PetCareAppMVC.Features.Location
{
    public class LocationViewModel
    {
        public int IdLocation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Level { get; set; }
        public bool IsHouse { get; set; }
    }
}
