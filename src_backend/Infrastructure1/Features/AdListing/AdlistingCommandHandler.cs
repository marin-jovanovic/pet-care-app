using MediatR;
using static DomainServices.Adlisting.Commands;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EFModel;
using AutoMapper;


namespace Infrastructure.Features.AdListing
{
    public class AdlistingCommandHandler : IRequestHandler<AddAdlisting, int>,IRequestHandler<DeleteAdlistingCommand>, IRequestHandler<UpdateAdlistingCommand>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public AdlistingCommandHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddAdlisting request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EFModel.Adlisting>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.IdAdListing;
        }

        public async Task<Unit> Handle(DeleteAdlistingCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Adlisting.FirstOrDefaultAsync(p => p.IdAdListing == request.idAdlisting);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateAdlistingCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Adlisting.FindAsync(request.IdAdListing);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
