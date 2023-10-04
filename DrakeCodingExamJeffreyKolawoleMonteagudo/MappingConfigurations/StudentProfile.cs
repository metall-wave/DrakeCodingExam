using AutoMapper;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Requests;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.MappingConfigurations
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentTbl, CreateStudentRequest>();
            CreateMap<CreateStudentRequest, StudentTbl>();
            CreateMap<StudentTbl, UpdateStudentRequest>();
            CreateMap<UpdateStudentRequest, StudentTbl>();
        }
    }
}
