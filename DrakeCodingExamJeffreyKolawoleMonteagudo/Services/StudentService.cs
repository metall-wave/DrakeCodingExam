using AutoMapper;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Requests;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Responses;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentTbl> AddAsync(CreateStudentRequest request)
        {
            var newStudent = _mapper.Map<StudentTbl>(request);

            var result = await _unitOfWork.Students.AddAsync(newStudent);

            _unitOfWork.Save();

            return result.Entity;
        }

        public async Task<StudentTbl> GetAsync(int id)
        {
            return await _unitOfWork.Students.GetAsync(id);
        }

        public async Task<IEnumerable<StudentTbl>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<bool> Update(int id, UpdateStudentRequest request)
        {
            var studentInDb = await GetAsync(id);

            if (studentInDb is null)
            {
                return false;
            }

            _mapper.Map(request, studentInDb);

            _unitOfWork.Students.Update(studentInDb);
            _unitOfWork.Save();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var studentInDb = await GetAsync(id);

            if (studentInDb is null)
            {
                return false;
            }

            _unitOfWork.Students.Delete(studentInDb);
            _unitOfWork.Save();

            return true;
        }

        public async Task<IEnumerable<GetStudentRecordsResponse>> GetStudentRecordsAsync(int id)
        {
            return await _unitOfWork.Students.GetStudentRecordsAsync(id);
        }
    }
}
