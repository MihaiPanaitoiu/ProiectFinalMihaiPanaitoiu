namespace ProiectFinalMihaiPanaitoiu.DTOS
{
    public class CourseToGetStudentMarkDto
    {
        public int MarkId { get; set; }
        public int MarkValue { get; set; }
        public DateTime? GivenDate { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
