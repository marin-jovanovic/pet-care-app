using AutoMapper;
using PetCareAppMVC.Features.People;
using PetCareAppMVC.Features.Adlisting;
using Domain;

namespace PetCareAppMVC;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
        CreateMap<PersonViewModel, DomainServices.People.Commands.AddPersonCommand>();
        CreateMap<PersonViewModel, DomainServices.People.Commands.UpdatePersonCommand>();

        CreateMap<Domain.People.Person, PersonViewModel>();

     
        CreateMap<Domain.Adlisting, AdlistingViewModel>();


    }
}
