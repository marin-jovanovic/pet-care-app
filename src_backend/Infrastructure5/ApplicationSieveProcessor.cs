using Infrastructure5.EFModel;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Infrastructure5;

public class ApplicationSieveProcessor : SieveProcessor
{
  public ApplicationSieveProcessor(IOptions<SieveOptions> options, ISieveCustomFilterMethods customFilterMethods) 
    : base(options, customFilterMethods)
  {
  }

  //protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
  //{
  //  mapper.Property<Project>(p => p.
  //  return mapper;
  //}
}
