using MediatR;
using static DomainServices.Adress.Commands;
using Microsoft.EntityFrameworkCore;
using Infrastructure5.EFModel;
using AutoMapper;


namespace Infrastructure5.Features.Adress
{
    public class AdressCommandHandler : IRequestHandler<AddAdressCommand, int>,IRequestHandler<DeleteAdressCommand>, IRequestHandler<UpdateAdressCommand>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public AdressCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddAdressCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.Adress>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.AdressId;
        }

        public async Task<Unit> Handle(UpdateAdressCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Adress.FirstOrDefaultAsync(p => p.AdressId == request.AdressId);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
       

        public async Task<Unit> Handle(DeleteAdressCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Adress.FindAsync(request.adressId);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
