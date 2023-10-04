using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Responses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Repositories
{
    public class StudentRepository : GenericRepository<StudentTbl>, IStudentRepository
    {
        public StudentRepository(DrakeCodingExamDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GetStudentRecordsResponse>> GetStudentRecordsAsync(int id)
        {
            var result = _context.Set<GetStudentRecordsResponse>().FromSql($"EXEC [dbo].[spGetStudentRecords] {id}");

            return await result.ToListAsync();
        }
    }
}
