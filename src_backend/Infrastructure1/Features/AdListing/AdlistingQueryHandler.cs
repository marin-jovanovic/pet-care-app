
using AutoMapper;
using Domain.People;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using static DomainServices.Adlisting.Queries;
using Infrastructure.EFModel;

namespace Infrastructure.Features.AdListing;
public class AdlistingQueryHandler : IRequestHandler<GetAdlistingQuery, IList<Domain.Adlisting>>,
    IRequestHandler<GetAdlistQuery, Domain.Adlisting>  
{
    private readonly ProjectContext ctx;
    private readonly ISieveProcessor sieveProcessor;
    private readonly IMapper mapper;
    public AdlistingQueryHandler(ProjectContext ctx, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        this.ctx=ctx;
        this.sieveProcessor=sieveProcessor;
        this.mapper=mapper;
    }
    public async Task<IList<Domain.Adlisting>> Handle(GetAdlistingQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Adlisting.AsNoTracking();
        if (request.Criteria != null)
        {
            query = sieveProcessor.Apply(request.Criteria, query);

        }
        var data = await query.Select(p => new Domain.Adlisting
        {
            UserName=p.UserName,    
            IdAdListing=p.IdAdListing,
            Description=p.Description,
            Price=p.Price
        }).ToListAsync(cancellationToken: cancellationToken);

        return data;    
    }


    public async Task<Domain.Adlisting> Handle(GetAdlistQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Adlisting.Where(p => p.IdAdListing == request.IdAdListing);
        var projectedQuery = mapper.ProjectTo<Domain.Adlisting>(query);
        var adlisting = await projectedQuery.FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return adlisting;
    }
}
