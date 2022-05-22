using AutoMapper;
using static DomainServices.Adress.Commands;
using static DomainServices.People.Commands;


namespace Infrastructure5;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AddPersonCommand, EFModel.Person>()
      .ForMember(person => person.UserName, opt => opt.MapFrom(command => command.UserName));
        CreateMap<UpdatePersonCommand, EFModel.Person>();
        CreateMap <EFModel.Person,UpdatePersonCommand > ();
        CreateMap<Infrastructure5.EFModel.Person, Domain.People.Person>();
        CreateMap<Domain.Adress, Infrastructure5.EFModel.Adress>();
        CreateMap<Infrastructure5.EFModel.Adress, Domain.Adress>();

        CreateMap<Domain.Adress, Infrastructure5.EFModel.Adress>();
        CreateMap<Infrastructure5.EFModel.Adress, Domain.Adress>();
        CreateMap<Infrastructure5.EFModel.Adress, UpdateAdressCommand>();
        CreateMap<UpdateAdressCommand, Infrastructure5.EFModel.Adress>();
        //AdressViewModel->AddAdressCommand PetCareAppMVC.Features.Adress.AdressViewModel->DomainServices.Adress.Commands + AddAdressCommand

        CreateMap<AddAdressCommand, Infrastructure5.EFModel.Adress>();
        CreateMap<DomainServices.Adress.Commands, Infrastructure5.EFModel.Adress>();
        CreateMap<Infrastructure5.EFModel.Adress, DomainServices.Adress.Commands.AddAdressCommand>();
        CreateMap< AddAdressCommand, EFModel.Adress>();

        CreateMap<EFModel.Pet, DomainServices.Pet.Commands>();
        CreateMap<DomainServices.Pet.Commands.CreatePet, EFModel.Pet>();
        CreateMap<DomainServices.Pet.Commands.UpdatePet, EFModel.Pet>();
        
        CreateMap< Infrastructure5.EFModel.Pet , Domain.Pet >();

        /*
    CreateMap<UpdatePersonCommand, EFModel.Person>()
      .ForMember(person => person.PersonalIdentificationNumber, opt => opt.MapFrom(command => command.PIN));
    CreateMap<AddProjectCommand, EFModel.Project>();
    CreateMap<UpdateProjectCommand, EFModel.Project>();

    CreateMap<EFModel.Project, Domain.Projects.Project>()
      .ForMember(dest => dest.ProjectTypeName , opt => opt.MapFrom(src => src.ProjectType.ProjectTypeName));*/
        //CreateMap<EFModel.Person, Domain.People.Person>()
        //.ForMember(dest => dest.PersonFirstName, opt => opt.MapFrom(src => src.UserName));
    
        CreateMap<EFModel.Person, Domain.People.Person>()
         .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

    }
}
