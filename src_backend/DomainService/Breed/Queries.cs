using MediatR;
using Domain;
namespace DomainServices.Breed
{
    public class Queries
    {
        public record GetBreedCommand : IRequest<Domain.Breed>;
    }
}
