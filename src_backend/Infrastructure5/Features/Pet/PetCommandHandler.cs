using MediatR;
using AutoMapper;
using Infrastructure5.EFModel;
using static DomainServices.Pet.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure5.Features.Pet
{
    internal class PetCommandHandler : IRequestHandler<CreatePet,int>,
        IRequestHandler<UpdatePet>,IRequestHandler<DeletePet>   
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public PetCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreatePet request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.Pet>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.PetId;
        }

        public async Task<Unit> Handle(DeletePet request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Pet.FindAsync(request.idPet);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePet request, CancellationToken cancellationToken)
        {

            var entity = await ctx.Pet.FirstOrDefaultAsync(p => p.PetId == request.PetId);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
            
        }
    }
}
