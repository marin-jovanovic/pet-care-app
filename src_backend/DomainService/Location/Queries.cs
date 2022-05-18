using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Location
{
    internal class Queries
    {

        public record GetLocationQuery : IRequest<Domain.Location>;
    }
}
