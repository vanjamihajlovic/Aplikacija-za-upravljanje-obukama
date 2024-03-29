﻿using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;

namespace CourseManagementApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, MentorDTO>().ReverseMap();
            CreateMap<User, CandidateDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();    
            CreateMap<Training, AllTrainingsResponseDTO>().ReverseMap();    
            CreateMap<Course, CourseDTO>().ReverseMap();    
            CreateMap<Course, TrainingCoursesDTO>().ReverseMap();    
        }
    }
}
