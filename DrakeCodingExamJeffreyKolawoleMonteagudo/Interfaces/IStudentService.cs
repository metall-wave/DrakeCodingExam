using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Requests;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Responses;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentTbl>>  GetAllAsync();
        Task<IEnumerable<GetStudentRecordsResponse>> GetStudentRecordsAsync(int id);
        Task<StudentTbl> GetAsync(int id);
        Task<StudentTbl> AddAsync(CreateStudentRequest request);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, UpdateStudentRequest request);
    }
}
