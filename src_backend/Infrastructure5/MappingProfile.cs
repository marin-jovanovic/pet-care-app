using AutoMapper;
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

        /*
    CreateMap<UpdatePersonCommand, EFModel.Person>()
      .ForMember(person => person.PersonalIdentificationNumber, opt => opt.MapFrom(command => command.PIN));
    CreateMap<AddProjectCommand, EFModel.Project>();
    CreateMap<UpdateProjectCommand, EFModel.Project>();

    CreateMap<EFModel.Project, Domain.Projects.Project>()
      .ForMember(dest => dest.ProjectTypeName , opt => opt.MapFrom(src => src.ProjectType.ProjectTypeName));*/
        //CreateMap<EFModel.Person, Domain.People.Person>()
        //.ForMember(dest => dest.PersonFirstName, opt => opt.MapFrom(src => src.UserName));

  }
}
