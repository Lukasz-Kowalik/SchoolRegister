using AutoMapper;
using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System.Linq;

namespace SchoolRegister.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression Mapping(
            this IMapperConfigurationExpression configurationExpression)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<AddOrUpdateSubjectDto, Subject>();
                mapper.CreateMap<Group, GroupVm>();
                mapper.CreateMap<Subject, SubjectVm>()
                    .ForMember(
                        dest => dest.TeacherName,
                        x => x.MapFrom(
                            src => $"{src.Teacher.FirstName} {src.Teacher.LastName}")
                        )
                    .ForMember(dest => dest.Groups,
                        x => x.MapFrom(
                            src => src.SubjectGroups.Select(y => y.Group)
                            )
                        );
                mapper.CreateMap<SubjectVm, AddOrUpdateSubjectDto>();
                mapper.CreateMap<Teacher, TeacherVm>();
                mapper.CreateMap<GradeDto, Grade>();
                mapper.CreateMap<Grade, GradeVm>();
                //to do dodac reszte map
            });
            return configurationExpression;
        }
    }
}