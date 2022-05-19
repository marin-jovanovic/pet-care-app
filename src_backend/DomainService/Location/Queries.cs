using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Location
{
    public class Queries
    {

        public record GetLocationsQuery : IRequest<IList<Domain.Location>>;

        public record GetLocationQuery(int IdLocation):IRequest<Domain.Location>;
    }
}
