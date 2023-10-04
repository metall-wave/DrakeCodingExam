using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DrakeCodingExamDbContext _context;
        private IStudentRepository _students;

        public IStudentRepository Students {
            get
            {
                if (_students == null)
                {
                    _students = new StudentRepository(_context);
                }
                return _students;
            }
        }

        public UnitOfWork(DrakeCodingExamDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
