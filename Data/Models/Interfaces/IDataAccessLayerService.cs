namespace Data.Models.Interfaces
{
    public interface IDataAccessLayerService
    {
        Course CreateCourse(Course course);
        IEnumerable<Course> GetCourses();
        Mark CreateMark(Mark mark);
        IEnumerable<Mark> GetMarksByStudentId(int studentId);
        IEnumerable<Mark> GetByStudentAndCourse(int studentId, int courseId);
        double GetAvgByStudentAndCourse(int studentId, int courseId);
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudents();
        void Seed();
        Student UpdateStudent(Student studentToUpdate);
        Address UpdateStudentAddress(int studentId, Address addressToUpdate);
        IEnumerable<(Student, double)> GetAritmeticMean(SortDirectionEnum sortDir);
    }
}