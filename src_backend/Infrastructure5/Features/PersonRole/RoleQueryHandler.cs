using MediatR;
using AutoMapper;
using static DomainServices.Role.Queries;
using Microsoft.EntityFrameworkCore;
using Infrastructure5.EFModel;
using static DomainServices.PersonRole.Queries;

namespace Infrastructure5.Features.PersonRole
{
    public class PersonRoleQueryHandler : IRequestHandler<GetPersonRolesQuery, IList<Domain.PersonRole>>, IRequestHandler<GetPersonRoleQuery, Domain.PersonRole>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public PersonRoleQueryHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.PersonRole>> Handle(GetPersonRolesQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.PersonRole
                          .Select(r => new Domain.PersonRole
                          {
                         
                              PersonId=r.PersonId,
                              RoleId=r.RoleId,
                              AdlistingId=r.AdlistingId,
                              AssigmentDate=r.AssigmentDate
                             
                              
                          })

                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }

        public async Task<Domain.PersonRole> Handle(GetPersonRoleQuery request, CancellationToken cancellationToken)
        {
            var query = ctx.PersonRole
                       .Where(p => p.PersonId == request.idPersonRole);
            var projectedQuery = mapper.ProjectTo<Domain.PersonRole>(query);
            var PersonRole = await projectedQuery.FirstOrDefaultAsync();



            return PersonRole;
        }
    }
  }

