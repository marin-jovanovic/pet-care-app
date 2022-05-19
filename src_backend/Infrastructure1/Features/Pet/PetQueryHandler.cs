using MediatR;
using AutoMapper;
using Infrastructure.EFModel;
using static DomainServices.Pet.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.Pet
{
    public class PetQueryHandler:IRequestHandler<GetPetsQuery, IList<Domain.Pet>>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PetQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Pet>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.Pet
                          .Select(r => new Domain.Pet
                          {
                              Age = r.Age,
                              IdPetType = r.IdPetType,
                              IdDescriptable = r.IdDescriptable,
                              PetId = r.PetId,
                              Description = r.Description,
                              Name = r.Name,
                              UserName = r.UserName 
                           })
                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }
    }
  }

