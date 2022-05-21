using AutoMapper;
using PetCareAppMVC.Features.People;
using PetCareAppMVC.Features.Adlisting;
using PetCareAppMVC.Features.Login;
using PetCareAppMVC.Features.Signup;
using Domain;


namespace PetCareAppMVC;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
       
        CreateMap<PersonViewModel, DomainServices.People.Commands.AddPersonCommand>();
        CreateMap<PersonViewModel, DomainServices.People.Commands.UpdatePersonCommand>();

        CreateMap<Domain.People.Person, PersonViewModel>();
        CreateMap<Domain.People.Person, LoginViewModel>();
        CreateMap<Domain.People.Person, SignupViewModel>();

        CreateMap<DomainServices.People.Commands, PetCareAppMVC.Features.Login.LoginViewModel>();
        CreateMap<DomainServices.People.Commands.UpdatePersonCommand, PetCareAppMVC.Features.Login.LoginViewModel>();
        CreateMap< PetCareAppMVC.Features.Login.LoginViewModel, DomainServices.People.Commands.UpdatePersonCommand>();

        CreateMap<Domain.Adlisting, AdlistingViewModel>();
        CreateMap<AdlistingViewModel, DomainServices.Adlisting2.Commands.AddAdlistingCommand2>();
        CreateMap<Infrastructure5.EFModel.AdListing, DomainServices.Adlisting2.Commands.AddAdlistingCommand2>();

      CreateMap<Infrastructure5.EFModel.AdListing ,DomainServices.Adlisting.Commands.AddAdlisting > ();

        CreateMap<Domain.People.Person, SignupViewModel> ();

        CreateMap<SignupViewModel, DomainServices.People.Commands.AddPersonCommand>();
    }
}
