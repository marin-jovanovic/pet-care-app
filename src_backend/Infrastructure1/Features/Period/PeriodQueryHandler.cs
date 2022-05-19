using Infrastructure.EFModel;
using MediatR;
using AutoMapper;

namespace Infrastructure.Features.Period
{
    internal class PeriodQueryHandler
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PeriodQueryHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

    }
}
