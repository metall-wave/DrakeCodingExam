namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IStudentRepository Students { get; }
        int Save();
    }
}
