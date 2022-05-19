using MediatR;
using AutoMapper;
using Infrastructure.EFModel;
using static DomainServices.Pettype.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.Pettype
{
    public class PettypeQueryHandler : IRequestHandler<GetPettypesQuery, IList<Domain.Pettype>>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PettypeQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Pettype>> Handle(GetPettypesQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.Pettype
                          .Select(r => new Domain.Pettype
                          {
                              IdPetType=r.IdPetType,
                              TypePetName=r.TypePetName
                          })
                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }
    }
}
