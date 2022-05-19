using MediatR;
using AutoMapper;
using Infrastructure.EFModel;
using static DomainServices.Location.Commands;

namespace Infrastructure.Features.Location
{
    public class LocationCommandHandler : IRequestHandler<AddLocationCommand, int>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public LocationCommandHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EFModel.Location>(request.IdLocation);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.IdLocation;
        }
    }
}
