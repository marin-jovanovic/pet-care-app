using System;
using Infrastructure.EFModel;
using MediatR;
using AutoMapper;

namespace Infrastructure.Features.Period
{
    public class PeriodCommandHandler
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PeriodCommandHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }   
    }
}
