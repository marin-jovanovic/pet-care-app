
using AutoMapper;
using Domain.People;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using static DomainServices.Adlisting.Queries;
using Infrastructure5.EFModel;

namespace Infrastructure5.Features.AdListing;
public class AdlistingQueryHandler : IRequestHandler<GetAdlistingQuery, IList<Domain.Adlisting>>,
    IRequestHandler<GetAdlistQuery, Domain.Adlisting>  
{
    private readonly PetCareApp2Context ctx;
    private readonly ISieveProcessor sieveProcessor;
    private readonly IMapper mapper;
    public AdlistingQueryHandler(PetCareApp2Context ctx, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        this.ctx=ctx;
        this.sieveProcessor=sieveProcessor;
        this.mapper=mapper;
    }
    public async Task<IList<Domain.Adlisting>> Handle(GetAdlistingQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.AdListing.AsNoTracking();
        if (request.Criteria != null)
        {
            query = sieveProcessor.Apply(request.Criteria, query);

        }
        var data = await query.Select(p => new Domain.Adlisting
        {
            AdlistingId=p.AdlistingId,
            PetId=p.PetId,
            AdlistingDescription=p.AdlistingDescription,
            EndDate=p.EndDate,
            IdAdress=p.IdAdress,
            IsActiv=p.IsActive,
            StartDate=p.StartDate,  
            Title=p.Title,  
            Price=p.Price
        }).ToListAsync(cancellationToken: cancellationToken);

        return data;    
    }


    public async Task<Domain.Adlisting> Handle(GetAdlistQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.AdListing.Where(p => p.AdlistingId == request.IdAdListing);
        var projectedQuery = mapper.ProjectTo<Domain.Adlisting>(query);
        var adlisting = await projectedQuery.FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return adlisting;
    }
}
