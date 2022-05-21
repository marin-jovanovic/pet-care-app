using MediatR;
using static DomainServices.Adlisting.Commands;
using Microsoft.EntityFrameworkCore;
using Infrastructure5.EFModel;
using AutoMapper;


namespace Infrastructure5.Features.AdListing
{
    public class AdlistingCommandHandler : IRequestHandler<AddAdlisting, int>,IRequestHandler<DeleteAdlistingCommand>, IRequestHandler<UpdateAdlistingCommand>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public AdlistingCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddAdlisting request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.AdListing>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.AdlistingId;
        }

        public async Task<Unit> Handle(DeleteAdlistingCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.AdListing.FirstOrDefaultAsync(p => p.AdlistingId == request.idAdlisting);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateAdlistingCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.AdListing.FindAsync(request.AdlistingId);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
