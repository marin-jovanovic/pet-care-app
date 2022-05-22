
using AutoMapper;
using Domain.People;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using Infrastructure5.EFModel;
using static DomainServices.People.Queries;
using static DomainServices.People.Commands;
using DomainServices.People;

namespace Infrastructure5.Features.People;
public class PeopleQueryHandler :
IRequestHandler<GetPeopleQuery, IList<Domain.People.Person>>,
    IRequestHandler<GetPersonQuery, Domain.People.Person>, IRequestHandler<GetPersonByUserNameQuery, Domain.People.Person>
{
    private readonly PetCareApp2Context ctx;
    private readonly ISieveProcessor sieveProcessor;
    private readonly IMapper mapper;

    public PeopleQueryHandler(PetCareApp2Context ctx, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        this.ctx = ctx;
        this.sieveProcessor = sieveProcessor;
        this.mapper = mapper;
    }

 

    public async Task<Domain.People.Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Person
                       .Where(p => p.PersonId == request.idPerson);
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
      var data = await query.Select(p => new Domain.People.Person(p.PersonId,p.PersonFirstName, p.UserName,p.PersonEmail,p.PersonLastName,p.Password, p.PersonMobile,p.SessionId,p.Oib))
                            .ToListAsync(cancellationToken: cancellationToken);
      return data;
    }

    public  async Task<Domain.People.Person> Handle(GetPersonByUserNameQuery request, CancellationToken cancellationToken)
    {
        var query = ctx.Person
                       .Where(p => p.UserName== request.userName);
        var projectedQuery = mapper.ProjectTo<Domain.People.Person>(query);
        var person = await projectedQuery.FirstOrDefaultAsync();



        return person;
    }
}



