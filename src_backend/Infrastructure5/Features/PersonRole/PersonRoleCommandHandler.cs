using MediatR;
using AutoMapper;
using Infrastructure5.EFModel;
using static DomainServices.PersonRole.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure5.Features.PersonRole
{
    internal class PersonRoleCommandHandler : IRequestHandler<AddPersonRoleCommand, int>,
        IRequestHandler<UpdatePersonRoleCommand>,IRequestHandler<DeletePersonRoleCommand>   
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public PersonRoleCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddPersonRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.PersonRole>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.PersonId;
        }

        public async Task<Unit> Handle(DeletePersonRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.PersonRole.FirstOrDefaultAsync(p => p.PersonId == request.personId);
            if (entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePersonRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.PersonRole.FindAsync(request.PersonId);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
