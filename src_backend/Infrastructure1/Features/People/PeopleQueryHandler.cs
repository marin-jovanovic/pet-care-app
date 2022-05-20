
using AutoMapper;
using Domain.People;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using Infrastructure.EFModel;
using static DomainServices.People.Queries;
using static DomainServices.People.Commands;

namespace Infrastructure.Features.People;
public class PeopleQueryHandler :
IRequestHandler<GetPeopleQuery, IList<Domain.People.Person>>,
    IRequestHandler<GetPersonQuery, Domain.People.Person>
{
    private readonly ProjectContext ctx;
    private readonly ISieveProcessor sieveProcessor;
    private readonly IMapper mapper;

    public PeopleQueryHandler(ProjectContext ctx, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        this.ctx = ctx;
        this.sieveProcessor = sieveProcessor;
        this.mapper = mapper;
    }

 

    public async Task<Domain.People.Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Person
                       .Where(p => p.IdPerson == request.idPerson);
        var projectedQuery = mapper.ProjectTo<Domain.People.Person>(query);
        var person = await projectedQuery.FirstOrDefaultAsync();
      

        

        return person;
    }

    public async Task<IList<Domain.People.Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Person.AsNoTracking();
      if (request.Criteria != null)
      {
        query = sieveProcessor.Apply(request.Criteria, query);
      }
      var data = await query.Select(p => new Domain.People.Person(p.IdPerson, p.UserName,p.Email,p.MobileNumber,p.Password))
                            .ToListAsync(cancellationToken: cancellationToken);
      return data;
    }

 
}



