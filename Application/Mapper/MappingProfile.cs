using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Assignment, AssignmentDTO>()
            .ForMember(dest => dest.TestCases, opt => opt.MapFrom(src => src.TestCases)).ReverseMap();

            CreateMap<TestCaseDTO, AssignmentTestCases>().ReverseMap();
        }
    }
}
