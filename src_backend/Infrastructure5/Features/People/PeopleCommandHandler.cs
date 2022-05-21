

using AutoMapper;
using Infrastructure5.EFModel;
using MediatR;
using static DomainServices.People.Commands;

namespace Infrastructure5.Features.People
{

    public class GetPeopleCommandHandler : IRequestHandler<AddPersonCommand, int>, IRequestHandler<DeletePersonCommand>, IRequestHandler<UpdatePersonCommand>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public GetPeopleCommandHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Infrastructure5.EFModel.Person>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.PersonId;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Person.FindAsync(request.personId);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity =await ctx.Person.FindAsync(request.PersonId);   
            if(entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();   
            }
            return Unit.Value;
        }
    }
    }
