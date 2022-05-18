using AutoMapper;
using static DomainServices.People.Commands;


namespace Infrastructure;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AddPersonCommand, EFModel.Person>()
      .ForMember(person => person.IdPerson, opt => opt.MapFrom(command => command.userName));
        /*
    CreateMap<UpdatePersonCommand, EFModel.Person>()
      .ForMember(person => person.PersonalIdentificationNumber, opt => opt.MapFrom(command => command.PIN));
    CreateMap<AddProjectCommand, EFModel.Project>();
    CreateMap<UpdateProjectCommand, EFModel.Project>();

    CreateMap<EFModel.Project, Domain.Projects.Project>()
      .ForMember(dest => dest.ProjectTypeName , opt => opt.MapFrom(src => src.ProjectType.ProjectTypeName));*/
    CreateMap<EFModel.Person, Domain.People.Person>()
     .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.IdPerson));

  }
}
