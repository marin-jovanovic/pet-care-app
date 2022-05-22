using MediatR;
using AutoMapper;
using static DomainServices.Pet.Queries;
using Microsoft.EntityFrameworkCore;
using Infrastructure5.EFModel;

namespace Infrastructure5.Features.Pet
{
    public class PetQueryHandler : IRequestHandler<GetPetsQuery, IList<Domain.Pet>>, IRequestHandler<GetPetQuery, Domain.Pet>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public PetQueryHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Pet>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.Pet
                          .Select(r => new Domain.Pet
                          {
                              Breed = r.Breed,
                              Size = r.Size,
                              PetId = r.PetId,
                              PetName = r.PetName,  
                              PetType = r.PetType,
                              Sex = r.Sex
                             
                          })

                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }

        public async Task<Domain.Pet> Handle(GetPetQuery request, CancellationToken cancellationToken)
        {
            var query = ctx.Pet
                       .Where(p => p.PetId == request.petId);
            var projectedQuery = mapper.ProjectTo<Domain.Pet>(query);
            var pet = await projectedQuery.FirstOrDefaultAsync();



            return pet;
        }
    }
  }

