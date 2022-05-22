
using DomainServices.Validation;
using FluentValidation;
using Infrastructure5.EFModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.People;

public class CheckUserNameUniquenessRequestHandler : IRequestHandler<CheckUserNameUniqueness, bool>
{
  private readonly PetCareApp2Context ctx;

  public CheckUserNameUniquenessRequestHandler(PetCareApp2Context ctx)
  {
    this.ctx = ctx;
  }

  public async Task<bool> Handle(CheckUserNameUniqueness request, CancellationToken cancellationToken)
  {
    bool alreadyExists = await ctx.Person
                                  .Where(p => p.UserName == request.userName)
                                  .Where(p => p.PersonId != request.PersonId)
                                  .AnyAsync();
    return !alreadyExists;
  }
}
