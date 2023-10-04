namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Responses
{
    public class GetStudentRecordsResponse
    {
        public string? StudentName { get; set; }
        public int StudentId { get; set; }
        public string? CityName { get; set; }
        public string? GenderName { get; set; }
        public string? CourseName { get; set; }
        public string? DegreeTypeName { get; set; }
        public int? CourseDurationInMonths { get; set; }
    }
}
