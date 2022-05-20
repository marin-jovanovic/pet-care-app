using Infrastructure.EFModel;
using MediatR;
using AutoMapper;
using static DomainServices.Period.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.Period
{
    internal class PeriodQueryHandler:IRequestHandler<GetPeriodsQuery,IList<Domain.Period>>
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PeriodQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<IList<Domain.Period>> Handle(GetPeriodsQuery request, CancellationToken cancellationToken)
        {

            var data = await ctx.Period
                          .Select(r => new Domain.Period
                          {
                              IdPeriod = r.IdPeriod,
                              EndDate = r.EndDate,
                              StartDate = r.StartDate
                          })
                                .ToListAsync(cancellationToken: cancellationToken);
            return data;

        }
    }
}
