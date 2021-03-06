﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                //view->dto
                mapper.CreateMap<SubjectVm, AddOrUpdateSubjectDto>();
                mapper.CreateMap<TeacherVm, TeacherDto>();
                mapper.CreateMap<GradeVm, GradeDto>();
                mapper.CreateMap<ParentVm, ParentDto>();
                mapper.CreateMap<StudentVm, StudentDto>();
                mapper.CreateMap<GroupVm, GradeDto>();
                mapper.CreateMap<GradeScaleVm, GradeScaleDto>();

                mapper.CreateMap<GroupVm, SelectListItem>()
                    .ForMember(x => x
                        .Text, y => y
                        .MapFrom(z => z.Name))
                    .ForMember(x => x
                        .Value, y => y
                        .MapFrom(z => z.Id));

                mapper.CreateMap<StudentVm, SelectListItem>()
                    .ForMember(x => x
                        .Text, y => y
                        .MapFrom(z => z.UserName))
                    .ForMember(x => x
                        .Value, y => y
                        .MapFrom(z => z.Id));

                //dto->entity
                mapper.CreateMap<AddOrUpdateSubjectDto, Subject>();
                mapper.CreateMap<GradeDto, Grade>();
                mapper.CreateMap<TeacherDto, Teacher>();
                mapper.CreateMap<ParentDto, Parent>();
                mapper.CreateMap<StudentDto, Student>();
                mapper.CreateMap<GradeDto, Group>();
                mapper.CreateMap<GradeScaleDto, GradeScale>();
                //entity->view
                mapper.CreateMap<GradeScale, GradeScaleVm>();
                mapper.CreateMap<Grade, GradeVm>();
                mapper.CreateMap<Parent, ParentVm>();
                mapper.CreateMap<Student, StudentVm>();
                mapper.CreateMap<SubjectGroup, SubjectGroupVm>();
                mapper.CreateMap<Group, GroupVm>();
                mapper.CreateMap<Teacher, TeacherVm>();
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
            });

            return configurationExpression;
        }
    }
}