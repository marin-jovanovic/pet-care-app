using AutoMapper;
using PetCareAppMVC.Features.People;
using PetCareAppMVC.Features.Adlisting;
using PetCareAppMVC.Features.Login;
using PetCareAppMVC.Features.Signup;
using Domain;
using PetCareAppMVC.Features.Adress;
using static DomainServices.Adress.Commands;
using PetCareAppMVC.Features.Pet;
using static DomainServices.Pet.Commands;
using DomainModel;
using DomainModel.Camunda;

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
        CreateMap<Domain.Adress, Infrastructure5.EFModel.Adress>();
        CreateMap<Infrastructure5.EFModel.Adress, Domain.Adress>();
        CreateMap<AdressViewModel, Domain.Adress >();
        CreateMap<Domain.Adress, PetCareAppMVC.Features.Adress.AdressViewModel>();
        CreateMap<AdressViewModel, UpdateAdressCommand>();
        CreateMap<Infrastructure5.EFModel.Adress, UpdateAdressCommand>();
        CreateMap<UpdateAdressCommand, Infrastructure5.EFModel.Adress>();
        CreateMap< AdressViewModel, AddAdressCommand>();
        CreateMap<DomainServices.Adress.Commands, AdressViewModel>();
        CreateMap<AdressViewModel, DomainServices.Adress.Commands>();

        CreateMap<DomainServices.Pet.Commands, PetViewModel>();
        CreateMap<AdressViewModel, UpdatePet>();
        CreateMap<Infrastructure5.EFModel.Adress, UpdatePet>();
        CreateMap<UpdatePet, Infrastructure5.EFModel.Adress>();
        CreateMap<DomainServices.Pet.Commands, PetCareAppMVC.Features.Pet.PetViewModel>();

        CreateMap< PetViewModel, DomainServices.Pet.Commands.CreatePet>();
        CreateMap<PetViewModel, DomainServices.Adress.Commands>();
        CreateMap<DomainServices.Pet.Commands.CreatePet, PetViewModel>();
        CreateMap<Infrastructure5.EFModel.Pet, DomainServices.Pet.Commands>();

        CreateMap< PetViewModel, DomainServices.Pet.Commands.UpdatePet>();

        CreateMap<PetViewModel, Domain.Pet>();
        CreateMap<Domain.Pet, PetViewModel>();

       
    }
}
