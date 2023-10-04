namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Requests
{
    public class CreateStudentRequest
    {
        public string? Name { get; set; }

        public string? CityId { get; set; }

        public int? CourseId { get; set; }

        public int? GenderId { get; set; }
    }
}
