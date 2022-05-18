

using AutoMapper;
using Infrastructure.EFModel;
using MediatR;
using static DomainServices.People.Commands;

namespace Infrastructure.Features.People
{

    public class GetPeopleQueryHandler : IRequestHandler<AddPersonCommand, int>
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
            var entity = mapper.Map<EFModel.Person>(request);
            ctx.Add(entity);
            await ctx.SaveChangesAsync();
            return entity.IdPerson;
        }
    }
    }
