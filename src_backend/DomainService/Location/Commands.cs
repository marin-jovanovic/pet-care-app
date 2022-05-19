using MediatR;
using Domain;

namespace DomainServices.Location

{
    public class Commands
    {
        public record DeleteLocationCommand(int idLocation) : IRequest;
        public class AddLocationCommand : IRequest<int>
        {
            public int IdLocation { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int Level { get; set; }
            public bool IsHouse { get; set; }
        }
        public class UpdateLocationCommand: IRequest
        {
            public int IdLocation { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int Level { get; set; }
            public bool IsHouse { get; set; }

        }
    }
}
