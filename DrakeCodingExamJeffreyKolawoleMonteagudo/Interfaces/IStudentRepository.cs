using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Responses;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces
{
    public interface IStudentRepository : IGenericRepository<StudentTbl>
    {
        Task<IEnumerable<GetStudentRecordsResponse>> GetStudentRecordsAsync(int id);
    }
}
