using MediatR;
using AutoMapper;
using Infrastructure.EFModel;
using static DomainServices.Location.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.Location
{
    public class LocationQueryHandler : IRequestHandler<GetLocationsQuery,IList<Domain.Location>>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public LocationQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.Location
                          .Select(r => new Domain.Location
                          {
                              IdLocation = r.IdLocation,
                              Longitude = r.Longitude,
                              Latitude = r.Latitude


                          })
                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }
    }
}
