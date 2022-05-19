using MediatR;
using AutoMapper;
using Infrastructure.EFModel;

namespace Infrastructure.Features.Pettype
{
    public class PettypeCommandHandler
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PettypeCommandHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
    }
}
