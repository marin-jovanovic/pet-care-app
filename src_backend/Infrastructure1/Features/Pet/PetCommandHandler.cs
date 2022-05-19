using MediatR;
using AutoMapper;
using Infrastructure.EFModel;

namespace Infrastructure.Features.Pet
{
    internal class PetCommandHandler
    {
        private readonly ProjectContext ctx;
        private readonly IMapper mapper;

        public PetCommandHandler(ProjectContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
    }
}
