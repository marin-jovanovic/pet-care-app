using MediatR;
using AutoMapper;
using static DomainServices.Role.Queries;
using Microsoft.EntityFrameworkCore;
using Infrastructure5.EFModel;

namespace Infrastructure5.Features.Role
{
    public class RoleQueryHandler:IRequestHandler<GetRolesQuery, IList<Domain.Role>>, IRequestHandler<GetRoleQuery, Domain.Role>
    {
        private readonly PetCareApp2Context ctx;
        private readonly IMapper mapper;

        public RoleQueryHandler(PetCareApp2Context ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var data = await ctx.Role
                          .Select(r => new Domain.Role
                          {
                         
                              RoleId = r.RoleId,
                              RoleName = r.RoleName,  
                              
                          })

                          .ToListAsync(cancellationToken: cancellationToken);
            return data;
        }

        public async Task<Domain.Role> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var query = ctx.Role
                       .Where(p => p.RoleId == request.RoleId);
            var projectedQuery = mapper.ProjectTo<Domain.Role>(query);
            var pet = await projectedQuery.FirstOrDefaultAsync();



            return pet;
        }
    }
  }

