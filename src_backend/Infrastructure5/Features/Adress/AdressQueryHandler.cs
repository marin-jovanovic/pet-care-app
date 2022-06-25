
using AutoMapper;
using Domain.People;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using static DomainServices.Adress.Queries;
using Infrastructure5.EFModel;

namespace Infrastructure5.Features.Adress;
public class AdressQueryHandler : IRequestHandler<GetAdressQuery, IList<Domain.Adress>>,
    IRequestHandler<GetOneAdressQuery, Domain.Adress>  
{
    private readonly PetCareApp2Context ctx;
    private readonly ISieveProcessor sieveProcessor;
    private readonly IMapper mapper;
    public AdressQueryHandler(PetCareApp2Context ctx, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        this.ctx=ctx;
        this.sieveProcessor=sieveProcessor;
        this.mapper=mapper;
    }
    public async Task<IList<Domain.Adress>> Handle(GetAdressQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Adress.AsNoTracking();
        if (request.Criteria != null)
        {
            query = sieveProcessor.Apply(request.Criteria, query);

        }
        var data = await query.Select(p => new Domain.Adress
        {
            AdressId = p.AdressId,
            Adress1=p.Adress1,  
            City=p.City,
            Country=p.Country,
            Floor=p.Floor,  
            IsHouse =p.IsHouse,
            PostalCode=p.PostalCode
            
        }).ToListAsync(cancellationToken: cancellationToken);

        return data;    
    }


    public async Task<Domain.Adress> Handle(GetOneAdressQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Adress.Where(p => p.AdressId == request.IdAdress);
        var projectedQuery = mapper.ProjectTo<Domain.Adress>(query);
        var adress = await projectedQuery.FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return adress;
    }
}
