

using AutoMapper;
using Infrastructure.EFModel;
using MediatR;
using static DomainServices.People.Commands;

namespace Infrastructure.Features.People
{

    public class GetPeopleQueryHandler : IRequestHandler<AddPersonCommand, int>, IRequestHandler<DeletePersonCommand>, IRequestHandler<UpdatePersonCommand>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public GetPeopleQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EFModel.Person>(request.idPerson);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.IdPerson;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await ctx.Person.FindAsync(request);
            if (entity != null)
            {
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity =await ctx.Person.FindAsync(request.idPerson);   
            if(entity != null)
            {
                mapper.Map(request, entity);
                await ctx.SaveChangesAsync();   
            }
            return Unit.Value;
        }
    }
    }
