using MediatR;
using AutoMapper;
using Infrastructure5.EFModel;
using static DomainServices.Role.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure5.Features.Role
{
    internal class RoleCommandHandler : IRequestHandler<CreateRole, int>,
        IRequestHandler<UpdateRole>,IRequestHandler<DeleteRole>   
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public RoleCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.Role>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.RoleId;
        }

        public async Task<Unit> Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Role.FirstOrDefaultAsync(p => p.RoleId == request.IdRole);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Role.FindAsync(request.RoleId);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
