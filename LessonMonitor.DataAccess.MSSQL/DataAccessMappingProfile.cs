﻿using AutoMapper;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Core.Member, Entities.Member>().ReverseMap();

            CreateMap<Core.Lesson, Entities.Lesson>().ReverseMap();
        }
    }
}
